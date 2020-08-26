namespace Challenge.API.UseCases.V1.Countries.Find
{
    public sealed class ResponseData
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Currencies { get; set; }
        public string EconomicBlocs { get; set; }
        public string Flag { get; set; }
        public long Population { get; set; }
        public string Timezone { get; set; }
        public string Languages { get; set; }
        public string Capital { get; set; }
        public string Borders { get; set; }
    }
}
