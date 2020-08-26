namespace Challenge.Domain.Interfaces
{
    public interface IEconomicBloc :
        IEntity
    {
        string Acronym { get; }
        string Name { get; }

    }
}
