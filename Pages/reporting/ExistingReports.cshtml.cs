using CHMR_DMP_PPR_Charlie_Docker.Database;
using CHMR_DMP_PPR_Charlie_Docker.Database.ReportingNS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHMR_DMP_PPR_Charlie_Docker.Pages.reporting
{
    public class ExistingReportsModel : PageModel
    {
        public string TrClass { get; set; } = string.Empty;
        public string TrStyle { get; set; } = string.Empty;

        [BindProperty]
        public List<Report> Reports { get { return ReportList; } }
        private List<Report> ReportList { get; set; } = new List<Report>();
        public void OnGet()
        {
            string? status = Request.Query["Status"].FirstOrDefault();
            if (string.IsNullOrEmpty(status))
                ReportList.AddRange(DmpDatabase.Reports);
            else
                ReportList.AddRange(DmpDatabase.Reports.Where(r => r.Status.ToString() == status));
        }
    }
}
