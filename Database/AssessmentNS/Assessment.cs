namespace CHMR_DMP_PPR_Charlie_Docker.Database.AssessmentNS
{
    public enum ERecommendationAS { None, Completed, CommanderInvestigation, CriminalInvestigation }
    public class Assessment : AssessmentBase<ERecommendationAS>
    {
        public enum ESuspectedCriminality { None, Serendipitous, Causation, LOACViolation }

        public ESuspectedCriminality SuspectedCriminality { get; set; } = ESuspectedCriminality.None;
        public bool EvidencedMoreLikelyThanNot { get; set; } = false;
        public Assessment() { Recommendation = ERecommendationAS.None; }

    }
}
