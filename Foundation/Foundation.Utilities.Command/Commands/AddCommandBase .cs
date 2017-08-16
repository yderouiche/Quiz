using Foundation.Domain.Entity;

namespace Foundation.Application.Commands
{
    public abstract class AddCommandBase<TEntity> : CommandBase
        where TEntity : IEntity
    {
        public AddCommandBase() : base()
        {
        }
    }
}
