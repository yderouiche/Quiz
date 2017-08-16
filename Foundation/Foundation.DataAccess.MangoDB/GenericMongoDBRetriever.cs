using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Foundation.Domain.Entity;
using Foundation.Domain.Retrievers;

namespace Foundation.DataAccess.MongoDB
{
    public class GenericMongoDBRetriever : IRetriever
    {
        MongoClient _client;
        IMongoDatabase _db;

        public GenericMongoDBRetriever(string connection, string databaseName)
        {
            _client = new MongoClient(connection);
            _db = _client.GetDatabase(databaseName);
        }

        public IList<QueryResult> Search<TEntity, QueryResult>(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> criteriaExpr, Expression<Func<TEntity, QueryResult>> mapToResultExpr)
            where TEntity : class, IEntity
            where QueryResult : class
        {
            return query.Where(criteriaExpr)
                        .Select(mapToResultExpr)
                        .ToList();
        }

        public IList<QueryResult> Search<TEntity, QueryResult>(Expression<Func<TEntity, bool>> criteriaExpr, Expression<Func<TEntity, QueryResult>> mapToResultExpr)
         where TEntity : class, IEntity
            where QueryResult : class
        {
            var query = GetQueryable<TEntity>();

            return this.Search(query, criteriaExpr, mapToResultExpr);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


        virtual protected IQueryable<TEntity> GetQueryable<TEntity>()
              where TEntity : class, IEntity
        {
            return _db.GetCollection<TEntity>(MongoHelper.GetCollectionName<TEntity>()).AsQueryable() as IQueryable<TEntity>;
        }

        PagedResults<QueryResult> IRetriever.Search<TEntity, QueryResult>(IQueryable<TEntity> query, Expression<Func<TEntity, bool>> criteriaExpr, Expression<Func<TEntity, QueryResult>> mapToResultExpr, int page, int pagesize)
        {
            throw new NotImplementedException();
        }

        PagedResults<QueryResult> IRetriever.Search<TEntity, QueryResult>(Expression<Func<TEntity, bool>> criteriaExpr, Expression<Func<TEntity, QueryResult>> mapToResultExpr, int page, int pagesize)
        {
            throw new NotImplementedException();
        }
    }

}

