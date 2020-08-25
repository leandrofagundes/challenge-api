namespace Challenge.Application.UseCases.V1.Countries.Get
{
    public sealed class OutputDataCountryRegionalBlocItem
    {
        public string Name { get; }

        public OutputDataCountryRegionalBlocItem(string name)
        {
            this.Name = name;
        }
    }
}
