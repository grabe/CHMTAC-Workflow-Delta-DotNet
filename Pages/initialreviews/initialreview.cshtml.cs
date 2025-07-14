using CHMR_DMP_PPR_Charlie_Docker.Configuration;
using CHMR_DMP_PPR_Charlie_Docker.Database;
using CHMR_DMP_PPR_Charlie_Docker.Database.AssessmentNS;
using CHMR_DMP_PPR_Charlie_Docker.Database.ReportingNS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;

namespace CHMR_DMP_PPR_Charlie_Docker.Pages.initialreviews
{
    public enum EAssociateMode { None, ReportUnderReview, Duplicative };
    public class initialreviewModel : PageModel
    {
        public List<Report> Reports = new List<Report>();
        public InitialReview? InitialReview { get; set; } = default(InitialReview);

        public void OnGet()
        {
            string? uuid = Request.Query["id"].FirstOrDefault();
            if (uuid?.Length > 0)
            {
                Guid guid = new Guid(uuid);
                InitialReview = DmpDatabase.InitialReviews.FirstOrDefault(u => u.Uuid == guid);
            }

            foreach (Report report in DmpDatabase.Reports)
            {
                if (report.Status == Report.EStatus.Submitted ||
                    (InitialReview?.ReportUnderReview != default(Report) && 
                     InitialReview?.ReportUnderReview?.Uuid == report.Uuid))
                {
                    Reports.Add(report);
                }
            }

            // add to model duplicative reports
            if (InitialReview != default(InitialReview))
            {
                foreach (var kvp in InitialReview?.DuplicativeReports)
                {
                    if (kvp.Value.ReviewUuid != Guid.Empty && kvp.Value.ReviewUuid == InitialReview?.Uuid)
                    {
                        Report? report = DmpDatabase.Reports.FirstOrDefault(r => r.Uuid == kvp.Value.ReportUuid);
                        Reports.Add(report);
                    }
                }
            }
        }

        public IActionResult OnPost()
        {
            Dictionary<string, Microsoft.Extensions.Primitives.StringValues> form = Request.Form.ToDictionary();
            bool includeInReview = form.ContainsKey("include_in_review") && form["include_in_review"] == "on";
            bool addlInfoUS = form.ContainsKey("addl_info_us_involve") && form["addl_info_us_involve"] == "on";
            string? irUuidStr = form.ContainsKey("initialreview_id") ? form["initialreview_id"] : default(string);
            string? reportUuidStr = form.ContainsKey("report_uuid") ? form["report_uuid"] : default(string);

            // no initial review record yet, so create one
            if (irUuidStr?.Length == 0)
            {
                InitialReview = new InitialReview();
                DmpDatabase.InitialReviews.Add(InitialReview);
                irUuidStr = InitialReview.Uuid.ToString();
            }

            // should never be <= 0
            if (irUuidStr?.Length > 0)
            {
                // find the initial review and save it to model
                InitialReview = DmpDatabase.InitialReviews.FirstOrDefault(u => u.Uuid.ToString() == irUuidStr);
                if (InitialReview != default(InitialReview))
                {
                    // find the report connected with changes
                    Report? report = DmpDatabase.Reports.FirstOrDefault(r => r.Uuid.ToString() == reportUuidStr);
                    if (report != default(Report))
                    {
                        // is report duplicative
                        bool isAssociated = InitialReview.DuplicativeReports.Count > 0 && InitialReview.DuplicativeReports.ContainsKey(report.Uuid);

                        // if flagged to include in review
                        if (includeInReview)
                        {
                            // if InitialReview has no report under review (RUR) 
                            if (InitialReview.ReportUnderReview == default(Report))
                            {
                                // if this report is associated remove that association 
                                if (isAssociated)
                                {
                                    InitialReview.DuplicativeReports.Remove(report.Uuid);
                                    report.Status = Report.EStatus.Submitted;
                                }

                                // set to report under review
                                InitialReview.ReportUnderReview = report;
                                report.Status = Report.EStatus.InReview;
                            }
                            // if this report is not the report under review then it is associated (duplicative)
                            else if (InitialReview.ReportUnderReview.Uuid != report.Uuid)
                            {
                                AssociatedReport? ar = default;
                                if (!InitialReview.DuplicativeReports.TryGetValue(report.Uuid, out ar))
                                {
                                    ar = new AssociatedReport(new Guid(irUuidStr), report.Uuid, addlInfoUS);
                                    InitialReview.DuplicativeReports.Add(report.Uuid, ar);
                                }
                                else
                                {
                                    ar.AddsValue = addlInfoUS;
                                }
                                    
                                report.Status = Report.EStatus.InReview;
                            }
                        }
                        else
                        {
                            // both of the following two if statements should never be true, but removing them both just in case
                            // if this report is associated then remove association because flag to include was false
                            if (isAssociated)
                            {
                                InitialReview.DuplicativeReports.Remove(report.Uuid);
                                report.Status = Report.EStatus.Submitted;
                            }

                            // if this report is RUR then clear it because flag to include was false
                            if (InitialReview.ReportUnderReview != default(Report) &&
                                InitialReview.ReportUnderReview?.Uuid == report.Uuid)
                            {
                                InitialReview.ReportUnderReview = default(Report);
                                report.Status = Report.EStatus.Submitted;
                            }
                        }
                    }

                    // if there are no reports connected with this InitialReview, delete it
                    if (InitialReview.ReportUnderReview == default(Report) && InitialReview.DuplicativeReports.Count == 0)
                    {
                        DmpDatabase.InitialReviews.Remove(InitialReview);
                        InitialReview = default;
                    }
                }
            }

            return RedirectToPage("/initialreviews/initialreview", new { id = InitialReview?.Uuid.ToString() });
        }
    }
}
