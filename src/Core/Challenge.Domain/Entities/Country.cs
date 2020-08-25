using Challenge.Domain.Interfaces;

namespace Challenge.Domain.Entities
{
    public abstract class Country :
        IAggregateRoot
    {
        public string Name { get; protected set; }
        public string Abbreviation { get; protected set; }
        public string Currencys { get; protected set; }
        public string Flag { get; protected set; }
        public string EconomicGroup { get; protected set; }
    }
}
