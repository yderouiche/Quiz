using MongoDB.Driver;
using System;
using System.Linq;
using Foundation.Domain.Entity;
using Foundation.Domain.Repositories;
using Foundation.Utilities.Functional;

namespace Foundation.DataAccess.MongoDB
{
    public class GenericMongoDBRepository<TEntity>:IRepository<TEntity>
        where TEntity : class, IEntity
    {

        /// <summary>
        /// 
        /// </summary>
        private MongoClient _client;

        /// <summary>
        /// 
        /// </summary>
        protected IMongoDatabase MongoDatabase { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public IMongoCollection<TEntity> MongoCollection
        {
            get
            {
                string collectionName=  MongoHelper.GetCollectionName<TEntity>();
                return MongoDatabase.GetCollection<TEntity>(collectionName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="databaseName"></param>
        public GenericMongoDBRepository(string connection, string databaseName)
        {
            _client = new MongoClient($"{connection}/{databaseName}");

            MongoDatabase = _client.GetDatabase(databaseName);
        }

        virtual public Option<TEntity> GetById(int  id)
        {
            return MongoCollection.Find(x=> x.Id.Equals(id)).FirstOrDefault();
        }


        virtual public TEntity Add(TEntity newEntity)
        {
            GenerateIdForEntity(newEntity, true);
            MongoCollection.InsertOne(newEntity);
           
            return newEntity;
        }

        virtual public void Update(TEntity entity)
        {
            if(entity.IsNew)
                throw new InvalidOperationException($"The entity is in new status and could not be updated");

            GenerateIdForEntity(entity, false);

            var filter = Builders<TEntity>.Filter.Eq(x=> x.Id,entity.Id);
            var operationResult = MongoCollection.ReplaceOne(filter, entity);

            if(operationResult.IsModifiedCountAvailable && operationResult.ModifiedCount==0)
                throw new InvalidOperationException($"No entity updated");
        }

        virtual public void Delete(int id)
        {
            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, id);
            var operation = MongoCollection.DeleteOne(filter);
        }

        virtual public void Delete(TEntity entity)
        {
            if (entity.IsNew)
                throw new InvalidOperationException($"The entity is in new status and could not be deleted");

            var filter = Builders<TEntity>.Filter.Eq(x => x.Id, entity.Id);
            var operation = MongoCollection.DeleteOne(filter);
        }

        virtual public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        virtual protected void GenerateIdForEntity(TEntity entity, bool isReset)
        {
            GenerateIdForEntity<TEntity>(entity, isReset);
        }

        virtual protected void GenerateIdForEntity<T>(T entity, bool isReset)
             where T : class, IEntity
        {
            if (entity.IsNew || isReset)
                entity.Id = MongoHelper.GetNextSequenceValue<T>(MongoDatabase);
        }
    }

}
