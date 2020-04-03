using System.Threading.Tasks;

namespace EventSourcing.Application.Infrastructure.Mediator
{
    public interface IRequestHandler<TRequest, TResponse>
    {
        Task<TResponse> Handle(TRequest request);
    }
}
