using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Foundation.Domain.Entity;
using Foundation.Domain.Retrievers;

namespace Foundation.DataAccess.EF
{

    public class GenericEFRetriever<TContext> : IRetriever
        where TContext : DbContext
    {
        protected TContext Context { get; set; }


        public GenericEFRetriever(TContext context)
        {
            Context = context;
        }

        public IList<QueryResult> Search<TEntity, QueryResult>(IQueryable<TEntity> query,
                                                                     Expression<Func<TEntity, bool>> criteriaExpr,
                                                                     Expression<Func<TEntity, QueryResult>> mapToResultExpr)
            where QueryResult : class
            where TEntity : class, IEntity
        {
            return query.Where(criteriaExpr)
                        .AsNoTracking()
                        .Select(mapToResultExpr)
                        .ToList();
        }

        public IList<QueryResult> Search<TEntity, QueryResult>(Expression<Func<TEntity, bool>> criteriaExpr, Expression<Func<TEntity, QueryResult>> mapToResultExpr)
           where QueryResult : class
           where TEntity : class, IEntity
        {
            return this.Search(Context.Set<TEntity>(), criteriaExpr, mapToResultExpr);
        }

        public PagedResults<QueryResult> Search<TEntity, QueryResult>(IQueryable<TEntity> query,
                                                                    Expression<Func<TEntity, bool>> criteriaExpr,
                                                                    Expression<Func<TEntity, QueryResult>> mapToResultExpr,
                                                                    int page,
                                                                    int pagesize)
           where QueryResult : class
           where TEntity : class, IEntity
        {
            var queryResult = query.Where(criteriaExpr);

            var pagedresult = new PagedResults<QueryResult>();


            pagedresult.PageNumber = page;
            pagedresult.PageSize = pagesize;
            pagedresult.RowCount = queryResult.Count();
            var pagecount = (double)pagedresult.RowCount / pagedresult.PageSize.Value;
            pagedresult.PagesCount = (int)Math.Ceiling(pagecount);

            var skipvalue = (page - 1) * pagesize;

            queryResult = queryResult.Skip(skipvalue).Take(pagesize);


            pagedresult.Results = this.Search(queryResult, criteriaExpr, mapToResultExpr);

            return pagedresult;
        }

        public PagedResults<QueryResult> Search<TEntity, QueryResult>(Expression<Func<TEntity, bool>> criteriaExpr,
                                                                    Expression<Func<TEntity, QueryResult>> mapToResultExpr,
                                                                    int page,
                                                                    int pagesize)
           where QueryResult : class
           where TEntity : class, IEntity
        {
            return this.Search(Context.Set<TEntity>(), criteriaExpr, mapToResultExpr, page, pagesize);
        }

        public void Dispose()
        {

        }


    }


}
