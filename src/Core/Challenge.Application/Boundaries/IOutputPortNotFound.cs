namespace Challenge.Application.Boundaries
{
    public interface IOutputPortNotFound
    {
        void NotFound(string message, object value);
    }
}
