namespace Challenge.Application.UseCases.V1.Countries.Get
{
    public sealed class OutputDataCountryEconomicBlocItem
    {
        public string Acronym { get; }
        public string Name { get; }

        public OutputDataCountryEconomicBlocItem(string acronym, string name)
        {
            this.Acronym = acronym;
            this.Name = name;
        }
    }
}
