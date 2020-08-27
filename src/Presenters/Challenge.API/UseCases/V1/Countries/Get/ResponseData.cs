namespace Challenge.API.UseCases.V1.Countries.Get
{
    public sealed class ResponseData
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public string Currencies { get; set; }
        public string EconomicBlocs { get; set; }
        public string Flag { get; set; }
    }
}
