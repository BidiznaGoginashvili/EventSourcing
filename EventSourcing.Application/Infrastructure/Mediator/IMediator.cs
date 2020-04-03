using System.Threading.Tasks;

namespace EventSourcing.Application.Infrastructure.Mediator
{
    public interface IMediator<TRequest, TResponse>
    {
        Task<TResponse> Send<TResponse>(TRequest request);
    }
}
