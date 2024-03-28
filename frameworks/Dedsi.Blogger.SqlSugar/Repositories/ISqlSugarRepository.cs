using System.Linq.Expressions;
using SqlSugar;

namespace Dedsi.Blogger.SqlSugar.Repositories;

public interface ISqlSugarRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class, new()
{

    Task<bool> InsertAsync(List<TEntity> entities);
    
    Task<bool> InsertAsync(TEntity entity);
    


    /// <summary>
    /// 所有字段更新
    /// </summary>
    /// <param name="entity"></param>
    /// <returns></returns>
    Task<bool> UpdateAsync(TEntity entity);

    /// <summary>
    /// 只更新某列
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="columns"></param>
    /// <returns></returns>
    Task<bool> UpdateColumnsAsync(TEntity entity, Expression<Func<TEntity, object>> columns);

    /// <summary>
    /// 不更新某列
    /// </summary>
    /// <param name="entity"></param>
    /// <param name="columns"></param>
    /// <returns></returns>
    Task<bool> IgnoreColumnsAsync(TEntity entity, Expression<Func<TEntity, object>> columns);

    Task<bool> DeleteAsync(TEntity entity);
    
    Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression);

    /// <summary>
    /// 主键删除
    /// </summary>
    /// <param name="id"></param>
    /// <typeparam name="TPrimaryKey"></typeparam>
    /// <returns></returns>
    Task<bool> DeleteAsync<TPrimaryKey>(TPrimaryKey id);
    
    /// <summary>
    /// 多个删除
    /// </summary>
    /// <param name="ids">一组主键Id</param>
    /// <typeparam name="TPrimaryKey"></typeparam>
    /// <returns></returns>
    Task<bool> DeleteAsync<TPrimaryKey>(IEnumerable<TPrimaryKey> ids);

    Task<int> ExecuteCommandAsync(string sql, object? parameters = null);

    /// <summary>
    /// 数据库事务
    /// </summary>
    /// <param name="action"></param>
    /// <returns></returns>
    Task DatabaseTransactionAsync(Func<ISqlSugarClient,Task> action);

}