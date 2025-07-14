using CHMR_DMP_PPR_Charlie_Docker.Database.ReportingNS;

namespace CHMR_DMP_PPR_Charlie_Docker.Database.SupportingNS
{
    public class Person
    {
        public Guid Uuid { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string AssignedUnit { get; set; } = string.Empty;
        public string ReportingUnit { get; set; } = string.Empty;
        public string DutyTitleRank { get; set; } = string.Empty;
        public string CommPhone { get; set; } = string.Empty;
        public string DsnPhone {  get; set; } = string.Empty; 
        public string Email { get; set; } = string.Empty;
        public string CombatCommand { get; set; } = string.Empty;
        public string OtherCommand {  get; set; } = string.Empty;

        public void SetValuesFromForm(Dictionary<string, Microsoft.Extensions.Primitives.StringValues> form)
        {
            if (form.ContainsKey("first_name"))
            {
                FirstName = form["first_name"].ToString();
            }
            if (form.ContainsKey("last_name"))
            {
                LastName = form["last_name"].ToString();
            }
            if (form.ContainsKey("reporting_unit"))
            {
                ReportingUnit = form["reporting_unit"].ToString();
            }
            if (form.ContainsKey("duty_title"))
            {
                DutyTitleRank = form["duty_title"].ToString();
            }
            if (form.ContainsKey("phone_commercial"))
            {
                CommPhone = form["phone_commercial"].ToString();
            }
            if (form.ContainsKey("phone_dsn"))
            {
                DsnPhone = form["phone_dsn"].ToString();
            }
            if (form.ContainsKey("email_address"))
            {
                Email = form["email_address"].ToString();
            }
            if (form.ContainsKey("unit_assigned_to"))
            {
                AssignedUnit = form["unit_assigned_to"].ToString();
            }
            if (form.ContainsKey("combat_command"))
            {
                CombatCommand = form["combat_command"].ToString();
            }
            if (form.ContainsKey("other_command") && (string.IsNullOrEmpty(CombatCommand) || CombatCommand.ToUpper() == "OTHER"))
            {
                OtherCommand = form["other_command"].ToString();
            }

        }
    }
}
