using System;
using System.Collections.Generic;

namespace RemoteLearning.TheUniverse.Infrastructure
{
    public class RequestBus
    {
        private readonly Dictionary<Type, Type> handlers = new Dictionary<Type, Type>();

        public void RegisterHandler(Type requestType, Type requestHandlerType)
        {
            if (!requestHandlerType.ImplementsInterface(typeof(IRequestHandler<,>)))
                throw new ArgumentException("requestHandlerType must inherit RequestHandlerBase", nameof(requestHandlerType));

            if (handlers.ContainsKey(requestType))
                throw new ArgumentException("requestType is already registered.", nameof(requestType));

            handlers.Add(requestType, requestHandlerType);
        }

        public Response Send<Request, Response> (Request request)
        {
            if (request == null) throw new ArgumentNullException(nameof(request));

            Type requestType = request.GetType();

            if (!handlers.ContainsKey(requestType))
                throw new Exception("Request handler not registered for the specified request.");

            Type requestHandlerType = handlers[requestType];

            IRequestHandler<Request, Response> requestHandler = (IRequestHandler<Request, Response>)Activator.CreateInstance(requestHandlerType);

            return requestHandler.Execute(request);
        }
    }
}
