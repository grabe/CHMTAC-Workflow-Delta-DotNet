namespace CHMR_DMP_PPR_Charlie_Docker.Database.CivilianHarmNS
{
    public class Baseline
    {
        public DateTime StartDatetime { get; set; } = DateTime.MinValue;
        public DateTime EndDatetime { get; set; } = DateTime.MinValue;
        public string Timezone { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string TotalCivilianHarm { get; set; } = string.Empty;
        public string UsCivilianHarm { get; set; } = string.Empty;

        public virtual void SetValuesFromForm(Dictionary<string, Microsoft.Extensions.Primitives.StringValues> form)
        {
            if (form.ContainsKey("incident_start_datetime"))
            {
                if (DateTime.TryParse(form["incident_start_datetime"].ToString(), out var startDatetime))
                {
                    StartDatetime = startDatetime;
                }
            }
            if (form.ContainsKey("incident_end_datetime"))
            {
                if (DateTime.TryParse(form["incident_end_datetime"].ToString(), out var startDatetime))
                {
                    EndDatetime = startDatetime;
                }
            }
            if (form.ContainsKey("time_zone"))
            {
                Timezone = form["time_zone"].ToString();
            }
            if (form.ContainsKey("location"))
            {
                Location = form["location"].ToString();
            }
            if (form.ContainsKey("total_harm"))
            {
                TotalCivilianHarm = form["total_harm"].ToString();
            }
            if (form.ContainsKey("us_harm"))
            {
                UsCivilianHarm = form["us_harm"].ToString();
            }

        }
    }
}
