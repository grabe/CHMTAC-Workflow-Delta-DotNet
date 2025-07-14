using CHMR_DMP_PPR_Charlie_Docker.Database.CivilianHarmNS;
using CHMR_DMP_PPR_Charlie_Docker.Database.SupportingNS;
using System.ComponentModel.DataAnnotations.Schema;
using static CHMR_DMP_PPR_Charlie_Docker.Database.ReportingNS.Report;

namespace CHMR_DMP_PPR_Charlie_Docker.Database.ReportingNS
{
    public class Report
    {
        public enum ESource { Unknown, Public, DoD }
        public enum EStatus { New, Submitted, InReview, Reviewed }
        public Guid Uuid { get; set; } = Guid.NewGuid();
        public DateTime Created { get; set; } = DateTime.Now;
        public ESource Source { get; set; } = ESource.Unknown;
        public EStatus Status { get; set; } = EStatus.New;
        public Person Reporter { get; set; } = new Person();
        public Baseline Baseline { get; set; } = new Baseline();
        public List<Document> Documentation { get; set; } = new List<Document> { };
        public string DocumentationUrl { get; set; } = string.Empty;
        public string AdditionalPoc1_Name { get; set; } = string.Empty;
        public string AdditionalPoc2_Name { get; set; } = string.Empty;
        public string AdditionalPoc1_Info { get; set; } = string.Empty;
        public string AdditionalPoc2_Info { get; set; } = string.Empty;

        public void SetValues(Report rhs)
        {
            Status = rhs.Status;
            Source = rhs.Source;
            AdditionalPoc1_Info = rhs.AdditionalPoc1_Info;
            AdditionalPoc2_Info = rhs.AdditionalPoc2_Info;
            AdditionalPoc1_Name = rhs.AdditionalPoc1_Name;
            AdditionalPoc2_Name = rhs.AdditionalPoc2_Name;
            DocumentationUrl = rhs.DocumentationUrl;

            Reporter.DsnPhone = rhs.Reporter.DsnPhone;
            Reporter.CommPhone = rhs.Reporter.CommPhone;
            Reporter.FirstName = rhs.Reporter.FirstName;
            Reporter.LastName = rhs.Reporter.LastName;
            Reporter.Email = rhs.Reporter.Email;
            Reporter.OtherCommand = rhs.Reporter.OtherCommand;
            Reporter.CombatCommand = rhs.Reporter.CombatCommand;
            Reporter.AssignedUnit = rhs.Reporter.AssignedUnit;
            Reporter.ReportingUnit = rhs.Reporter.ReportingUnit;
            Reporter.DutyTitleRank = rhs.Reporter.DutyTitleRank;

            Baseline.EndDatetime = rhs.Baseline.EndDatetime;
            Baseline.StartDatetime = rhs.Baseline.StartDatetime;
            Baseline.Location = rhs.Baseline.Location;
            Baseline.Timezone = rhs.Baseline.Timezone;
            Baseline.TotalCivilianHarm = rhs.Baseline.TotalCivilianHarm;
            Baseline.UsCivilianHarm = rhs.Baseline.UsCivilianHarm;
        }

        public Report() { }

        public Report(Dictionary<string, Microsoft.Extensions.Primitives.StringValues> form, ESource source, bool saveForLater)
        {
            Status = saveForLater ? EStatus.New : EStatus.Submitted;
            Source = source;

            Reporter.SetValuesFromForm(form);
            Baseline.SetValuesFromForm(form);

            if (form.ContainsKey("poc1_name"))
            {
                AdditionalPoc1_Name = form["poc1_name"].ToString();
            }
            if (form.ContainsKey("poc1_contact_info"))
            {
                AdditionalPoc1_Info = form["poc1_contact_info"].ToString();
            }
            if (form.ContainsKey("poc2_name"))
            {
                AdditionalPoc2_Name = form["poc2_name"].ToString();
            }
            if (form.ContainsKey("poc2_contact_info"))
            {
                AdditionalPoc2_Info = form["poc2_contact_info"].ToString();
            }
            if (form.ContainsKey("documentation_url"))
            {
                DocumentationUrl = form["documentation_url"].ToString();
            }

        }
    }
}
