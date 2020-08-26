namespace Challenge.Application.UseCases.V1.Countries.Find
{
    public sealed class OutputDataRegionalBloc
    {
        public string Name { get; }

        public OutputDataRegionalBloc(string name)
        {
            this.Name = name;
        }
    }
}
