using Challenge.Application.UseCases.V1.Countries.GetByRegion;

namespace Challenge.Application.Tests.UseCases.V1.GetByRegion
{
    public sealed class Presenter :
        IOutputPort
    {
        public OutputData OutputData { get; private set; }

        public void Cancelled()
        {
            this.OutputData = null;
        }

        public void ExternalServiceError()
        {
            this.OutputData = null;
        }

        public void Success(OutputData outputData)
        {
            this.OutputData = outputData;
        }
    }
}
