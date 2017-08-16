using Paramore.Brighter;
using System;

namespace Quiz.API.Factories
{
    internal class SimpleHandlerFactory : IAmAHandlerFactory
    {
        IServiceProvider _serviceProvider;

        public SimpleHandlerFactory(IServiceProvider app)
        {
            _serviceProvider = app;
        }

        public IHandleRequests Create(Type handlerType)
        {
            return (IHandleRequests)_serviceProvider.GetService(handlerType);
        }

        public void Release(IHandleRequests handler)
        {
            var disposable = handler as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }
            handler = null;
        }
    }
}
