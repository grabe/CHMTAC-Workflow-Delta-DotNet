namespace CHMR_DMP_PPR_Charlie_Docker.Database.SupportingNS
{
    public class Operation
    {
        public enum EKinetic { NonKinetic, Kinetic }
        public enum EOperational { NonOperational, Operational }
        public Domains Domains { get; set; } = new Domains();
        public List<Location> Locations { get; set; } = new List<Location>();
        public List<Unit> ParticipatingUnits { get; set; } = new List<Unit>();
        public List<Weapon> WeaponsUsed { get; set; } = new List<Weapon>();
        public Fires Fires { get; set; } = new Fires();
        public string Summary { get; set; } = string.Empty;
    }
}
