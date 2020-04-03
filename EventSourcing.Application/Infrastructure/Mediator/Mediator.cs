using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace EventSourcing.Application.Infrastructure.Mediator
{
    public class Mediator<TRequest, TResponse> : IMediator<TRequest, TResponse>
    {
        public Task<TResponse> Send<TResponse>(TRequest request)
        {
            try
            {
                RequestHandler(request);

                return default;
            }
            catch (ArgumentNullException exception) when (request == null)
            {
                throw new ArgumentNullException();
            }
        }

        public TResponse RequestHandler(TRequest request)
        {
            var handler = Assembly.GetExecutingAssembly().GetTypes()
                          .Where(t => t.IsSubclassOf(typeof(IRequestHandler<TRequest, TResponse>))).FirstOrDefault();

            var instance = Activator.CreateInstance(handler);

            var parameter = new object[] { (TRequest)Activator.CreateInstance(typeof(TRequest)) };

            var response = handler.GetMethod("Handle").Invoke(instance, parameter);

            return (TResponse)response;
        }
    }
}
