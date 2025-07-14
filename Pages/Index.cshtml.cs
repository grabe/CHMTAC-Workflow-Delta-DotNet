using CHMR_DMP_PPR_Charlie_Docker.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CHMR_DMP_PPR_Charlie_Docker.Pages
{
    [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
    public class IndexModel : PageModel
    {
        public ConfigurationPoco.ESecurityRole Role { get; private set; } = ConfigurationPoco.ESecurityRole.None;
        public string Username { get; private set; } = string.Empty;
        public string Password { get; private set; } = string.Empty;
        public static bool IsLoggedOn { get { return CHMR_DMP_PPR_Charlie_Docker.Configuration.ConfigurationPoco.IsLoggedOn; } }

        public void OnGet()
        {
            Username = string.Empty;
            Password = string.Empty;
            CHMR_DMP_PPR_Charlie_Docker.Configuration.ConfigurationPoco.IsLoggedOn = false;
        }

        public IActionResult OnPost()
        {
            CHMR_DMP_PPR_Charlie_Docker.Configuration.ConfigurationPoco.IsLoggedOn = false;
            Dictionary<string, Microsoft.Extensions.Primitives.StringValues> loginForm = Request.Form.ToDictionary();
            Username = loginForm["username"];
            Password = loginForm["password"];
            if ((Username != null) && (Password != null))
            {
                Role = ConfigurationPoco.GetRole(Username, Password);

                CHMR_DMP_PPR_Charlie_Docker.Configuration.ConfigurationPoco.IsLoggedOn = Role != ConfigurationPoco.ESecurityRole.None;
            }

            return CHMR_DMP_PPR_Charlie_Docker.Configuration.ConfigurationPoco.IsLoggedOn ? RedirectToPage("dod/"+Role.ToString().ToLower()+"/index") : RedirectToPage("/Public/chirf");
        }
    }
}
