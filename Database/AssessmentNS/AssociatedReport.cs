namespace CHMR_DMP_PPR_Charlie_Docker.Database.AssessmentNS
{
    public class AssociatedReport
    {
        public Guid Uuid { get; set; } = Guid.NewGuid();
        public Guid ReviewUuid { get; set; }
        public Guid ReportUuid { get; set; }
        public bool AddsValue { get; set; } = false;

        public AssociatedReport(Guid reviewUuid, Guid reportUuid, bool addsValue = false)
        {
            ReviewUuid = reviewUuid;
            ReportUuid = reportUuid;
            AddsValue = addsValue;
        }
    }
}
