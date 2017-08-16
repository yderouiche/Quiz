using System;
using Foundation.Domain.Entity;
using Foundation.Utilities.Functional;


namespace Foundation.Domain.Repositories
{

    public interface IRepository<TEntity>:IDisposable
        where TEntity :  IEntity
    {
        TEntity Add(TEntity newEntity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(int id);

        Option<TEntity> GetById(int id);
    }
}
