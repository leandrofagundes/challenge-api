namespace Challenge.Domain.Interfaces
{
    public interface ICurrency :
        IEntity
    {
        string Code { get; }
        string Name { get; }
        string Symbol { get; }
    }
}
