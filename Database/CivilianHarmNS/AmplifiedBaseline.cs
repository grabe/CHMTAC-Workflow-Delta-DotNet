namespace CHMR_DMP_PPR_Charlie_Docker.Database.CivilianHarmNS
{
    public class AmplifiedBaseline : Baseline
    {
        public string UScausedCivilianDeaths { get; set; } = string.Empty;
        public string UScausedCivilianInjuries {  get; set; } = string.Empty;
        public string UScausedCivilianPropertyDestroyed {  get; set; } = string.Empty;
        public string UScausedCivilianPropertyDamaged {  get; set; } = string.Empty;

        public override void SetValuesFromForm(Dictionary<string, Microsoft.Extensions.Primitives.StringValues> form)
        {
            base.SetValuesFromForm(form);

            if (form.ContainsKey("us_caused_civilian_deaths"))
            {
                UScausedCivilianDeaths = form["us_caused_civilian_deaths"].ToString();
            }
            if (form.ContainsKey("us_caused_civilian_deaths"))
            {
                UScausedCivilianInjuries = form["us_caused_civilian_injuries"].ToString();
            }
            if (form.ContainsKey("us_caused_civilian_deaths"))
            {
                UScausedCivilianPropertyDestroyed = form["us_caused_civilian_property_destroyed"].ToString();
            }
            if (form.ContainsKey("us_caused_civilian_deaths"))
            {
                UScausedCivilianPropertyDamaged = form["us_caused_civilian_property_damaged"].ToString();
            }
        }
    }
}
