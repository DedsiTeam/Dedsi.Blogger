using System.Linq.Expressions;
using SqlSugar;

namespace Dedsi.Blogger.SqlSugar.Repositories;

public class SqlSugarRepository<TEntity>(ISqlSugarClient dbClient)
    : ReadOnlyRepository<TEntity>(dbClient),  ISqlSugarRepository<TEntity> where TEntity : class, new()
{
    public async Task<bool> InsertAsync(List<TEntity> entities)
    {
        var resultCount = 0;
        if (entities.Count > 10000)
        {
            resultCount = await dbClient.Fastest<TEntity>().BulkCopyAsync(entities);
        }
        else
        {
            resultCount = await dbClient.Insertable(entities).ExecuteCommandAsync();
        }

        return resultCount == entities.Count;
    }
    
    public async Task<bool> InsertAsync(TEntity entity)
    {
        var resultCount = await dbClient.Insertable(entity).ExecuteCommandAsync();
        return resultCount == 1;
    }

    
    public async Task<bool> UpdateAsync(TEntity entity)
    {
        var resultCount = await dbClient.Updateable(entity).ExecuteCommandAsync();
        return resultCount == 1;
    }
    
    public async Task<bool> UpdateColumnsAsync(TEntity entity,Expression<Func<TEntity, object>> columns)
    {
        var resultCount = await dbClient.Updateable(entity).UpdateColumns(columns).ExecuteCommandAsync();
        return resultCount == 1;
    }
    
    public async Task<bool> IgnoreColumnsAsync(TEntity entity,Expression<Func<TEntity, object>> columns)
    {
        var resultCount = await dbClient.Updateable(entity).IgnoreColumns(columns).ExecuteCommandAsync();
        return resultCount == 1;
    }
    
    
    public async Task<bool> DeleteAsync(TEntity entity)
    {
        var resultCount = await dbClient.Deleteable(entity).ExecuteCommandAsync();
        return resultCount == 1;
    }

    public async Task<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
    {
        var resultCount = await dbClient.Deleteable<TEntity>().Where(expression).ExecuteCommandAsync();
        return resultCount > 0;
    }

    public async Task<bool> DeleteAsync<TPrimaryKey>(TPrimaryKey id)
    {
        var resultCount = await dbClient.Deleteable<TEntity>().In(id).ExecuteCommandAsync();
        return resultCount == 1;
    }
    
    public async Task<bool> DeleteAsync<TPrimaryKey>(IEnumerable<TPrimaryKey> ids)
    {
        var resultCount = await dbClient.Deleteable<TEntity>().In(ids.ToArray()).ExecuteCommandAsync();
        return resultCount == ids.Count();
    }

    public Task<int> ExecuteCommandAsync(string sql, object? parameters = null)
    {
        return dbClient.Ado.ExecuteCommandAsync(sql,parameters);
    }

    public async Task DatabaseTransactionAsync(Func<ISqlSugarClient,Task> action)
    {
        try
        {
            await dbClient.Ado.BeginTranAsync();
            await action(dbClient);
            await dbClient.Ado.CommitTranAsync();
        }
        catch (Exception e)
        {
            await dbClient.Ado.RollbackTranAsync();
            throw;
        }
    }
    
}