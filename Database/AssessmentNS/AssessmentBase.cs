using CHMR_DMP_PPR_Charlie_Docker.Database.CivilianHarmNS;
using CHMR_DMP_PPR_Charlie_Docker.Database.ReportingNS;
using CHMR_DMP_PPR_Charlie_Docker.Database.SupportingNS;

namespace CHMR_DMP_PPR_Charlie_Docker.Database.AssessmentNS
{
    public enum ECommanderApproval { None, Approved, Rejected }
    public class AssessmentBase<T> where T : System.Enum
    {
        public Guid Uuid { get; set; } = Guid.NewGuid();
        public Report? ReportUnderReview { get; set; } = default;
        public Dictionary<Guid, AssociatedReport> DuplicativeReports { get; set; } = new Dictionary<Guid, AssociatedReport>();
        public List<Operation> OperationsInvolved { get; set; } = new List<Operation>();
        public List<InformationSource> SourcesOfInformation { get; set; } = new List<InformationSource>();
        public string Title { get; set; } = string.Empty;
        public AmplifiedBaseline AmplifiedBaseline { get; set; } = new AmplifiedBaseline();
        public T Recommendation { get; set; }
        public string Summary { get; set; } = string.Empty;
        public ECommanderApproval CommanderApproval { get; set; } = ECommanderApproval.None;
    }
}
