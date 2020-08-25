using Challenge.Domain.Interfaces;

namespace Challenge.Domain.Entities
{
    public abstract class EconomicBloc :
        IEconomicBloc
    {
        public string Acronym { get; protected set; }
        public string Name { get; protected set; }

        protected EconomicBloc(
            string acronym, 
            string name)
        {
            this.Acronym = acronym;
            this.Name = name;
        }
    }
}
