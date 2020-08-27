namespace Challenge.Application.UseCases.V1.Countries.GetByRegion
{
    public sealed class OutputDataCountryItem
    {
        public string Name { get; }
        public string Abbreviation { get; }
        public string Flag { get; }

        public OutputDataCountryItem(
            string name,
            string abbreviation,
            string flag)
        {
            this.Name = name;
            this.Abbreviation = abbreviation;
            this.Flag = flag;
        }
    }
}
