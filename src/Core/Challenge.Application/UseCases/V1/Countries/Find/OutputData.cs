using Challenge.Application.Boundaries;

namespace Challenge.Application.UseCases.V1.Countries.Find
{
    public sealed class OutputData :
        IOutputData
    {
        public string Name { get; }
        public string CIOC { get; }
        public OutputDataCurrency[] Currencies { get; }
        public OutputDataRegionalBloc[] RegionalBlocs { get; }

        public OutputData(
            string name,
            string cioc,
            OutputDataCurrency[] currencies,
            OutputDataRegionalBloc[] regionalBlocs)
        {
            this.Name = name;
            this.CIOC = cioc;
            this.Currencies = currencies;
            this.RegionalBlocs = regionalBlocs;
        }
    }
}
