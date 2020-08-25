using Challenge.Application.Boundaries;

namespace Challenge.Application.UseCases.V1.Countries.Find
{
    public interface IOutputPort :
        IOutputPortSuccess<OutputData>,
        IOutputPortNotFound
    {

    }
}
