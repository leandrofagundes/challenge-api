namespace Challenge.Application.UseCases.V1.Countries.GetRoute
{
    public sealed class OutputDataRouteCountryItem
    {
        public string Name { get; }
        public string Flag { get; }

        public OutputDataRouteCountryItem(
            string name,
            string flag)
        {
            this.Name = name;
            this.Flag = flag;
        }
    }
}
