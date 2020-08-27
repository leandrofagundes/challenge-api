using Challenge.Application.Boundaries;

namespace Challenge.Application.UseCases.V1.Countries.GetRoute
{
    public interface IOutputPort :
        IOutputPortSuccess<OutputData>,
        IOutputPortInvalidData
    {

    }
}
