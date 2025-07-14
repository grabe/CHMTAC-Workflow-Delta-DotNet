using CHMR_DMP_PPR_Charlie_Docker.Database;
using CHMR_DMP_PPR_Charlie_Docker.Database.ReportingNS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHMR_DMP_PPR_Charlie_Docker.Pages.reporting
{
    public class NewreportModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            bool savedForLater = Request.Form.Keys.Contains("save_for_later");
            IFormFileCollection files = Request.Form.Files;
            Dictionary<string, Microsoft.Extensions.Primitives.StringValues> form = Request.Form.ToDictionary();

            DmpDatabase.Reports.Add(new Report(form, Report.ESource.DoD, savedForLater));
            //DmpDatabase.Reports
            return RedirectToPage("../reporting/reportingworkspace");
        }
    }
}
