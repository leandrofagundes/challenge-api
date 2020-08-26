namespace Challenge.Domain.Interfaces
{
    public interface ICountry :
        IAggregateRoot
    {
        string Name { get; }
        string Abbreviation { get; }
        string Flag { get; }
        long Population { get; }
        string Capital { get; }
        string[] Timezones { get; }
        ICurrency[] Currencies { get; }
        IEconomicBloc[] EconomicGroups { get; }
        string[] Languages { get; }
        string[] Borders { get; }
    }
}
