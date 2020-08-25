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


        public Country(
            string name,
            string abbreviation,
            string flag,
            ICurrency[] currencies,
            IEconomicBloc[] economicBlocs)
        {
            this.Name = name;
            this.Abbreviation = abbreviation;
            this.Flag = flag;
            this.Currencies = currencies;
            this.EconomicGroups = economicBlocs;
        }
    }
}
