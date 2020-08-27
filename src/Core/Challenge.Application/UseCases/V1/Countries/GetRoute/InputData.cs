using Challenge.Application.Boundaries;

namespace Challenge.Application.UseCases.V1.Countries.GetRoute
{
    public sealed class InputData :
        IInputData
    {
        public string Origin { get; }
        public string Destiny { get; }

        public InputData(string origin, string destiny)
        {
            this.Origin = origin;
            this.Destiny = destiny;
        }
    }
}
