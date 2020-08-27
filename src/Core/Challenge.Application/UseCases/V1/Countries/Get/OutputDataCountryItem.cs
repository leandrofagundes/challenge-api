namespace Challenge.Application.UseCases.V1.Countries.Get
{
    public sealed class OutputDataCountryItem
    {
        public string Name { get; }
        public string Abbreviation { get; }
        public string Flag { get; }
        public OutputDataCountryCurrencyItem[] Currencies { get; }
        public OutputDataCountryEconomicBlocItem[] EconomicBlocs { get; }

        public OutputDataCountryItem(
            string name,
            string abbreviation,
            string flag,
            OutputDataCountryCurrencyItem[] currencies,
            OutputDataCountryEconomicBlocItem[] economicBlocs)
        {
            this.Name = name;
            this.Abbreviation = abbreviation;
            this.Flag = flag;
            this.Currencies = currencies;
            this.EconomicBlocs = economicBlocs;
        }
    }
}
