using CleanArch.Domain.Products;

namespace CleanArch.Application.Data.Interfaces;
public interface IRespository<TEntity, TEntityId>
{
    Task<TEntity?> GetByIDAsync(TEntityId id);
    Task<List<TEntity>> GetAllAsync();
    IQueryable<TEntity> GetQueryable(); 
    void Add(TEntity entity); 
    void Update(TEntity entity); 
    void Delete(TEntity entity);
}