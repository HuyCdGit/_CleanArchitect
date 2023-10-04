namespace CleanArch.Application.Data.Interfaces;
public interface IRespository<TEntity, TEntityId>
{
    Task<TEntity?> GetByIDAsync(TEntityId id);
    Task<List<TEntity>> GetAllAsync();
    IQueryable<TEntity> GetQueryable(); 
    Task AddAysnc(TEntity menu, CancellationToken cancellationToken);
    void Update(TEntity entity); 
    void Delete(TEntity entity);
}