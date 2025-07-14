using System.Buffers;
using CHMR_DMP_PPR_Charlie_Docker.Database.CivilianHarmNS;
using CHMR_DMP_PPR_Charlie_Docker.Database.ReportingNS;
using CHMR_DMP_PPR_Charlie_Docker.Database.SupportingNS;

namespace CHMR_DMP_PPR_Charlie_Docker.Database.AssessmentNS
{
    public enum ERecommendationIR { None, CloseBogus, CloseUsNotInvolved, RecommendAssessment, RecommendInvestigation }
    public class InitialReview : AssessmentBase<ERecommendationIR>
    {
        public InitialReview() { Recommendation = ERecommendationIR.None; } 
    }
}
