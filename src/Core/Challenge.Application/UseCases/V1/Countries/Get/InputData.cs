using Challenge.Application.Boundaries;

namespace Challenge.Application.UseCases.V1.Countries.Get
{
    public sealed class InputData :
        IInputData
    {
        public string Filter { get; }

        public InputData(string filter)
        {
            this.Filter = filter;
        }
    }
}
