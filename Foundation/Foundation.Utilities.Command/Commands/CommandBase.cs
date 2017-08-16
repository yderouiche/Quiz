using System;

namespace Foundation.Application.Commands
{
    public abstract class CommandBase : Paramore.Brighter.Command, ICanBeValidated
    {
        public CommandBase() : base(Guid.NewGuid())
        {
        }

        public bool IsValid()
        {
            return true;
        }
    }
}
