using Challenge.Application.Boundaries;

namespace Challenge.Application.UseCases.V1.Countries.Find
{
    public sealed class InputData :
        IInputData
    {
        public string NumericCode { get; }

        public InputData(string numericCode)
        {
            this.NumericCode = numericCode;
        }
    }
}
