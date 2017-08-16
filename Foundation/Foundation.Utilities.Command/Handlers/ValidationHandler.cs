using Foundation.Application.Commands;
using Paramore.Brighter;
using System;

namespace Foundation.Application.Handlers
{
    public class ValidationHandler<TRequest> : RequestHandler<TRequest>
        where TRequest : class, IRequest, ICanBeValidated
    {
        public override TRequest Handle(TRequest command)
        {
            if (!command.IsValid())
            {
                throw new ArgumentException("The commmand was not valid");
            }

            return base.Handle(command);
        }
    }
}
