namespace Challenge.Application.Boundaries
{
    public interface IOutputPortSuccess<TOutputData>
        where TOutputData : IOutputData
    {
        public void Success(TOutputData outputData);
    }
}
