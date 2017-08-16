using Foundation.Application.Commands;
using Foundation.Domain.Entity;
using Foundation.Domain.Repositories;
using Paramore.Brighter;

namespace Foundation.Application.Handlers
{

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class AddCommandHandlerBase<TCommand, TEntity> : CommandHandlerBase<TCommand>
        where TCommand : AddCommandBase<TEntity>
        where TEntity : IEntity
    {
        /// <summary>
        /// 
        /// </summary>
        private readonly IRepository<TEntity> _repository;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repoistory"></param>
        public AddCommandHandlerBase(IRepository<TEntity> repoistory)
        {
            _repository = repoistory;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Validation(step: 1, timing: HandlerTiming.Before)]
        public override TCommand Handle(TCommand command)
        {           
            var entity = CreateEntity(command);

            _repository.Add(entity);
            
            return base.Handle(command);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        protected abstract TEntity CreateEntity(TCommand command);
    }
}
