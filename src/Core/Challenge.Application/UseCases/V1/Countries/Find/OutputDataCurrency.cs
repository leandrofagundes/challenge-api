namespace Challenge.Application.UseCases.V1.Countries.Find
{
    public sealed class OutputDataCurrency
    {
        public string Name { get; }

        public OutputDataCurrency(string name)
        {
            this.Name = name;
        }
    }
}
