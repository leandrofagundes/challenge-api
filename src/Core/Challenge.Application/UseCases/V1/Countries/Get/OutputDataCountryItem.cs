namespace Challenge.Application.UseCases.V1.Countries.Get
{
    public sealed class OutputDataCountryItem
    {
        public string Name { get; }
        public string CIOC { get; }
        public OutputDataCountryCurrencyItem[] Currencies { get; }
        public OutputDataCountryRegionalBlocItem[] RegionalBlocs { get; }

        public OutputDataCountryItem(
            string name,
            string cioc,
            OutputDataCountryCurrencyItem[] currencies,
            OutputDataCountryRegionalBlocItem[] regionalBlocs)
        {
            this.Name = name;
            this.CIOC = cioc;
            this.Currencies = currencies;
            this.RegionalBlocs = regionalBlocs;
        }
    }
}
