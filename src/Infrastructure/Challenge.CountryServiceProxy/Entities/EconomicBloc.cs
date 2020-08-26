namespace Challenge.CountryServiceProxy.Entities
{
    public sealed class EconomicBloc :
        Domain.Entities.EconomicBloc
    {
        public EconomicBloc(
            string acronym, 
            string name) : 
            base(acronym, name)
        {
        }
    }
}
