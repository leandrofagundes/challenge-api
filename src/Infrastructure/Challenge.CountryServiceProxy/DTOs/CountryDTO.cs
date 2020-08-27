namespace Challenge.CountryServiceProxy.DTOs
{
    public sealed class CountryDTO
    {
        public string Name { get; set; }
        public string Alpha3Code { get; set; }
        public string Flag { get; set; }
        public string Region { get; set; }
        public CurrencyDTO[] Currencies { get; set; }
        public RegionalBlocDTO[] RegionalBlocs { get; set; }
        public LanguageDTO[] Languages { get; set; }
        public string Capital { get; set; }
        public long Population { get; set; }
        public string[] Timezones { get; set; }
        public string[] Borders { get; set; }
    }
}
