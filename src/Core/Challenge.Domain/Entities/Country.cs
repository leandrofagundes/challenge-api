using Challenge.Domain.Interfaces;

namespace Challenge.Domain.Entities
{
    public abstract class Country :
        ICountry
    {
        public string Name { get; protected set; }
        public string Abbreviation { get; protected set; }
        public string Flag { get; protected set; }
        public ICurrency[] Currencies { get; protected set; }
        public IEconomicBloc[] EconomicGroups { get; protected set; }

        protected Country(
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
