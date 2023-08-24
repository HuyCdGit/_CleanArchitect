using CleanArch.Domain.Products;

namespace CleanArch.Application.Data.Interfaces;
public interface IRespository<TEntity>
{
    Task<List<TEntity>> GetAllAsync();
    IQueryable<TEntity> GetQueryable(); 
    void Add(TEntity entity); 
    void Update(TEntity entity); 
    void Delete(TEntity entity);
    Task<int> SaveChangeAsync(CancellationToken cancellationToken);
}