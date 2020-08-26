namespace Challenge.Application.UseCases.V1.Countries.Find
{
    public sealed class OutputDataEconomicBloc
    {
        public string Acronym { get; }
        public string Name { get; }

        public OutputDataEconomicBloc(string acronym, string name)
        {
            this.Acronym = acronym;
            this.Name = name;
        }
    }
}
