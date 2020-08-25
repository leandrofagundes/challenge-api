namespace Challenge.CountryServiceProxy.Entities
{
    public sealed class Country
         : Domain.Entities.Country
    {
        public Country(
            string name, 
            string abbreviation, 
            string flag, 
            Currency[] currencies, 
            EconomicBloc[] economicBlocs) 
            : base(name, abbreviation, flag, currencies, economicBlocs)
        {

        }
    }
}
