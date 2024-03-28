using System.Linq.Expressions;
using SqlSugar;

namespace Dedsi.Blogger.SqlSugar.Repositories;

public class ReadOnlyRepository<TEntity>(ISqlSugarClient dbClient) : IReadOnlyRepository<TEntity>
{
    protected ISugarQueryable<TEntity> GetQueryable() => dbClient.Queryable<TEntity>();
    
    public Task<ISugarQueryable<TEntity>> GetQueryableAsync()
    {
        return Task.FromResult(GetQueryable());
    }

    public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
    {
        return GetQueryable().AnyAsync(expression);
    }

    public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
    {
        return GetQueryable().FirstAsync(expression);
    }

    public Task<TEntity> GetAsync<TPrimaryKey>(TPrimaryKey id)
    {
        return GetQueryable().In(id).FirstAsync();
    }

    public Task<List<TEntity>> GetListAsync()
    {
        return GetQueryable().ToListAsync();
    }
    
    public Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression)
    {
        return GetQueryable().Where(expression).ToListAsync();
    }
    
    public Task<List<TEntity>> GetListAsync(string sql, object? whereObj = null)
    {
        return dbClient.Ado.SqlQueryAsync<TEntity>(sql,whereObj);
    }

    public Task<List<T>> GetListAsync<T>(string sql, object? whereObj = null)
    {
        return dbClient.Ado.SqlQueryAsync<T>(sql,whereObj);
    }

    public Task<List<TEntity>> GetPageListAsync(
        int pageNumber, 
        int pageSize, 
        RefAsync<int> totalNumber,
        Expression<Func<TEntity, bool>> whereExpression,
        Expression<Func<TEntity, object>> orderExpression, 
        OrderByType orderByType = OrderByType.Asc)
    {
        return GetQueryable()
                .Where(whereExpression)
                .OrderBy(orderExpression, orderByType)
                .ToPageListAsync(pageNumber,pageSize,totalNumber);
    }

    public Task<int> CountAsync()
    {
        return GetQueryable().CountAsync();
    }

    public Task<int> CountAsync(Expression<Func<TEntity, bool>> expression)
    {
        return GetQueryable().CountAsync(expression);
    }
    
    public Task<int> CountAsync(string sql, object? whereObj = null)
    {
        return dbClient.Ado.SqlQuerySingleAsync<int>(sql,whereObj);
    }

}