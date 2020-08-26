namespace Challenge.Application.UseCases.V1.Countries.Get
{
    public sealed class OutputDataCountryCurrencyItem
    {
        public string Name { get; }

        public OutputDataCountryCurrencyItem(string name)
        {
            this.Name = name;
        }
    }
}
