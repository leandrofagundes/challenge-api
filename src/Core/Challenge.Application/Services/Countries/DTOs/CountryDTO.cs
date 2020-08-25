namespace Challenge.Application.Services.Countries.DTOs
{
    public sealed class CountryDTO
    {
        public string Name { get; set; }

        public string CIOC { get; set; }

        public CurrencyDTO[] Currencies { get; set; }

        public RegionalBlocDTO[] RegionalBlocs { get; set; }
    }
}
