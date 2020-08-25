namespace Challenge.CountryServiceProxy.Entities
{
    public sealed class Currency :
        Domain.Entities.Currency
    {
        public Currency(
            string code, 
            string name, 
            string symbol) : 
            base(code, name, symbol)
        {
        }
    }
}
