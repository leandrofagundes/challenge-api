using Challenge.Application.Boundaries;

namespace Challenge.Application.UseCases.V1.Countries.Get
{
    public interface IOutputPort :
        IOutputPortSuccess<OutputData>,
        IOutputPortExternalServiceError
    {
    }
}
