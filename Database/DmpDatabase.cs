using CHMR_DMP_PPR_Charlie_Docker.Database.AssessmentNS;
using CHMR_DMP_PPR_Charlie_Docker.Database.CommanderNS;
using CHMR_DMP_PPR_Charlie_Docker.Database.ReportingNS;
using System.Diagnostics.Eventing.Reader;

namespace CHMR_DMP_PPR_Charlie_Docker.Database
{
    public sealed class DmpDatabase
    {
        public static List<Report> Reports { get; set; } = new List<Report>();
        public static List<InitialReview> InitialReviews { get; set; } = new List<InitialReview>();
        public static List<Assessment> Assessments { get; set; } = new List<Assessment>();
        public static List<Investigation> Investigations { get; set; } = new List<Investigation>();

        public static bool UpdateReport(string uuid, Report updReport)
        {
            Report? report = Reports.FirstOrDefault(r => r.Uuid.ToString() == uuid);
            bool success = report != null;
            if (success)
            {
                report?.SetValues(updReport);
            }
            return success;
        }
    }
}
