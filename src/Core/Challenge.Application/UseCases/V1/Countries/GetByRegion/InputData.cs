using Challenge.Application.Boundaries;

namespace Challenge.Application.UseCases.V1.Countries.GetByRegion
{
    public sealed class InputData :
        IInputData
    {
        public string RegionName { get; }

        public InputData(string regionName)
        {
            this.RegionName = regionName;
        }
    }
}
