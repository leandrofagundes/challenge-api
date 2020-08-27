using Challenge.Application.Boundaries;

namespace Challenge.Application.UseCases.V1.Countries.Find
{
    public sealed class InputData :
        IInputData
    {
        public string Name { get; }

        public InputData(string name)
        {
            this.Name = name;
        }
    }
}
