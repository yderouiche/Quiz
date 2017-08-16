using Foundation.Application.Commands;
using Paramore.Brighter;

namespace Foundation.Application.Handlers
{
    public abstract class CommandHandlerBase<TCommand>: RequestHandler<TCommand>
        where TCommand : CommandBase
    {

    }
}
