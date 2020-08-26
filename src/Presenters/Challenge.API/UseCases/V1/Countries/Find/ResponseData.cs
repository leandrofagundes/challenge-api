namespace Challenge.API.UseCases.V1.Countries.Find
{
    public sealed class ResponseData
    {
        public string Name { get; set; }
        public string CIOC { get; set; }
        public ResponseDataCurrency[] Currencies { get; set; }
        public ResponseDataRegionalBloc[] RegionalBlocs { get; set; }
    }
}
