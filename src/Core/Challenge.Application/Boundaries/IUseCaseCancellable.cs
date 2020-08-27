using System.Threading;
using System.Threading.Tasks;

namespace Challenge.Application.Boundaries
{
    public interface IUseCaseCancellable<TInputData>
         where TInputData : IInputData
    {
        Task Execute(TInputData inputData, CancellationToken token);
    }
}
