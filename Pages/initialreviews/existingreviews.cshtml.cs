using CHMR_DMP_PPR_Charlie_Docker.Database;
using CHMR_DMP_PPR_Charlie_Docker.Database.AssessmentNS;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHMR_DMP_PPR_Charlie_Docker.Pages.initialreviews
{
    public class ExistingReviewsModel : PageModel
    {
        public string TrClass { get; set; } = string.Empty;
        public string TrStyle { get; set; } = string.Empty;

        [BindProperty]
        public List<InitialReview> Reviews { get { return ReviewList; } }
        private List<InitialReview> ReviewList { get; set; } = new List<InitialReview>();
        public void OnGet()
        {
            string? cmdrApproval = Request.Query["CommanderApproval"].FirstOrDefault();
            if (string.IsNullOrEmpty(cmdrApproval))
                ReviewList.AddRange(DmpDatabase.InitialReviews);
            else
                ReviewList.AddRange(DmpDatabase.InitialReviews.Where(r => r.CommanderApproval.ToString() == cmdrApproval));
        }
    }
}
