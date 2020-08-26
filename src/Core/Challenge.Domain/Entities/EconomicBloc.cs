using Challenge.Domain.Interfaces;

namespace Challenge.Domain.Entities
{
    public sealed class EconomicBloc :
        IEconomicBloc
    {
        public EconomicBloc(
            string acronym,
            string name)
        {
            this.Acronym = acronym;
            this.Name = name;
        }

        public string Acronym { get; private set; }

        public string Name { get; private set; }
    }
}
