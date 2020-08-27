using Challenge.Application.Boundaries;

namespace Challenge.Application.UseCases.V1.Countries.Find
{
    public sealed class OutputData :
        IOutputData
    {
        public string Name { get; }
        public string Abbreviation { get; }
        public long Population { get; }
        public string Capital { get; }
        public string Flag { get; }
        public string Region { get; }
        public OutputDataCurrency[] Currencies { get; }
        public OutputDataEconomicBloc[] EconomicBlocs { get; }
        public string[] Languages { get; }
        public string[] Timezones { get; }
        public string[] Borders { get; }

        public OutputData(
            string name,
            string abbreviation,
            string flag,
            long population,
            string capital,
            string region,
            OutputDataCurrency[] currencies,
            OutputDataEconomicBloc[] economicBlocs,
            string[] languages,
            string[] timezones,
            string[] borders)
        {
            this.Name = name;
            this.Abbreviation = abbreviation;
            this.Flag = flag;
            this.Capital = capital;
            this.Region = region;
            this.Population = population;
            this.Currencies = currencies;
            this.EconomicBlocs = economicBlocs;
            this.Languages = languages;
            this.Timezones = timezones;
            this.Borders = borders;
        }
    }
}
