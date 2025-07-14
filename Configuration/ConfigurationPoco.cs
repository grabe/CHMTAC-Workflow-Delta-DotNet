namespace CHMR_DMP_PPR_Charlie_Docker.Configuration
{
    public sealed class ConfigurationPoco
    {
        public enum ESecurityRole { None, DODUSER, CHAC, CMDR, CHMRO, CCDR }
        public static bool IsLoggedOn {  get; set; }
        public static IConfiguration AppSettings { get; } = new ConfigurationBuilder()
                                                                .SetBasePath(Directory.GetCurrentDirectory())
                                                                .AddJsonFile("appsettings.json")
                                                                .Build();
        public static ESecurityRole Role { get; private set; }
        public static ESecurityRole GetRole(string login, string password)
        {
            ESecurityRole role = ESecurityRole.None;

            string pwdKey = "Logins:" + login.ToLower() + ":password";
            string roleKey = "Logins:" + login.ToLower() + ":role";

            string? truePwd = ConfigurationPoco.AppSettings[pwdKey];
            if (truePwd == password)
            {
                var srole = ConfigurationPoco.AppSettings[roleKey];
                bool validLogin = Enum.TryParse<ConfigurationPoco.ESecurityRole>(srole, out role);
            }

            Role = role;
            return role;
        }
    }
}
