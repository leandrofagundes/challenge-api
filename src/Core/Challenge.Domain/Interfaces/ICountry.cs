namespace Challenge.Domain.Interfaces
{
    public interface ICountry :
        IAggregateRoot
    {
        string Name { get; }
        string Abbreviation { get; }
        string Flag { get; }
        ICurrency[] Currencies { get; }
        IEconomicBloc[] EconomicGroups { get; }
    }
}
