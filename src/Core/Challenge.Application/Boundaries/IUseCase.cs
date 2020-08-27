using System.Threading.Tasks;

namespace Challenge.Application.Boundaries
{
    public interface IUseCase<TInputData>
        where TInputData : IInputData
    {
        Task Execute(TInputData inputData);
    }
}
