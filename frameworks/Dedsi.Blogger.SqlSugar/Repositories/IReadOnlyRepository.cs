using System.Linq.Expressions;
using SqlSugar;
using Volo.Abp.DependencyInjection;

namespace Dedsi.Blogger.SqlSugar.Repositories;

public interface IReadOnlyRepository<TEntity>: ITransientDependency
{
    Task<ISugarQueryable<TEntity>> GetQueryableAsync();
    
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
    
    Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression);
    
    Task<TEntity> GetAsync<TPrimaryKey>(TPrimaryKey id);

    Task<List<TEntity>> GetListAsync();
    Task<List<TEntity>> GetListAsync(Expression<Func<TEntity, bool>> expression);

    Task<List<TEntity>> GetListAsync(string sql, object? whereObj = null);
    Task<List<T>> GetListAsync<T>(string sql, object? whereObj = null);

    Task<List<TEntity>> GetPageListAsync(
        int pageNumber,
        int pageSize,
        RefAsync<int> totalNumber,
        Expression<Func<TEntity, bool>> whereExpression,
        Expression<Func<TEntity, object>> orderExpression,
        OrderByType orderByType = OrderByType.Asc);

    Task<int> CountAsync();
    
    Task<int> CountAsync(Expression<Func<TEntity, bool>> expression);

    Task<int> CountAsync(string sql, object? whereObj = null);
}