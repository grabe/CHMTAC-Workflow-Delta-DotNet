namespace CHMR_DMP_PPR_Charlie_Docker.Database.SupportingNS
{
    public class Weapon
    {
        public string TargetingProcess { get; set; } = string.Empty;
        public Location LocationOfShooter { get; set; } = new Location();
        public Location IntendedTargetLocation {  get; set; } = new Location();
        public string WeaponSystem { get; set; } = string.Empty;
        public string Munitions { get; set; } = string.Empty;
        public int EstimatedRoundsFired { get; set; } = 0;
    }
}
