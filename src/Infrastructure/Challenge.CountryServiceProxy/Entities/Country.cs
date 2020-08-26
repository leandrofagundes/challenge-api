using Challenge.Domain.Interfaces;

namespace Challenge.CountryServiceProxy.Entities
{
    public sealed class Country
         : ICountry
    {
        public string Name { get; private set; }
        public string Abbreviation { get; private set; }
        public string Flag { get; private set; }
        public ICurrency[] Currencies { get; private set; }
        public IEconomicBloc[] EconomicGroups { get; private set; }

        public long Population { get; private set; }

        public string[] Timezones { get; private set; }

        public string[] Languages { get; private set; }

        public string[] Borders { get; private set; }

        public string Capital { get; private set; }

        public Country(
            string name,
            string abbreviation,
            string flag,
            long population,
            string capital,
            ICurrency[] currencies,
            IEconomicBloc[] economicBlocs,
            string[] timezones,
            string[] languages,
            string[] borders)
        {
            this.Name = name;
            this.Abbreviation = abbreviation;
            this.Flag = flag;
            this.Capital = capital;
            this.Currencies = currencies;
            this.EconomicGroups = economicBlocs;
            this.Population = population;
            this.Languages = languages;
            this.Timezones = timezones;
            this.Borders = borders;
        }
    }
}
