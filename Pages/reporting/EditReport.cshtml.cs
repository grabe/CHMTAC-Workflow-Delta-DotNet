using CHMR_DMP_PPR_Charlie_Docker.Database;
using CHMR_DMP_PPR_Charlie_Docker.Database.ReportingNS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.ComponentModel;

namespace CHMR_DMP_PPR_Charlie_Docker.Pages.reporting
{
    public class EditreportModel : PageModel
    {
        [BindProperty]
        public Report? Report { get; set; } = null;

        public void OnGet()
        {
            string? uuid = Request.Query["id"].FirstOrDefault();
            Report = DmpDatabase.Reports.Where(r => r.Uuid.ToString() == uuid).FirstOrDefault();
        }

        public IActionResult OnPost()
        {
            bool savedForLater = Request.Form.Keys.Contains("save_for_later");
            string? uuid = Request.Form["report_id"];
            IFormFileCollection files = Request.Form.Files;
            Dictionary<string, Microsoft.Extensions.Primitives.StringValues> form = Request.Form.ToDictionary();

            DmpDatabase.UpdateReport(uuid, new Report(form, Report.ESource.DoD, savedForLater));
            //DmpDatabase.Reports
            return RedirectToPage("../reporting/reportingworkspace");
        }
    }
}
