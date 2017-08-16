using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Foundation.Domain.Entity;

namespace Foundation.Domain.Retrievers
{
    public interface IRetriever: IDisposable
    {

        IList<QueryResult> Search<TEntity, QueryResult>(IQueryable<TEntity> query,
                                                                     Expression<Func<TEntity, bool>> criteriaExpr,
                                                                     Expression<Func<TEntity, QueryResult>> mapToResultExpr)
            where QueryResult : class
            where TEntity : class, IEntity;

        IList<QueryResult> Search<TEntity, QueryResult>(Expression<Func<TEntity, bool>> criteriaExpr, Expression<Func<TEntity, QueryResult>> mapToResultExpr)
           where QueryResult : class
           where TEntity : class, IEntity;

        PagedResults<QueryResult> Search<TEntity, QueryResult>(IQueryable<TEntity> query,
                                                                   Expression<Func<TEntity, bool>> criteriaExpr,
                                                                   Expression<Func<TEntity, QueryResult>> mapToResultExpr,
                                                                   int page,
                                                                   int pagesize)
          where QueryResult : class
          where TEntity : class, IEntity;

        PagedResults<QueryResult> Search<TEntity, QueryResult>(Expression<Func<TEntity, bool>> criteriaExpr,
                                                                   Expression<Func<TEntity, QueryResult>> mapToResultExpr,
                                                                   int page,
                                                                   int pagesize)
          where QueryResult : class
          where TEntity : class, IEntity;

    }
}
