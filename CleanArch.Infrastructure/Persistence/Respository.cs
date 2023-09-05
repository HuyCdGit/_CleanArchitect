using CleanArch.Application.Data.Interfaces;
using CleanArch.Domain.Primitives;
using CleanArch.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Persistence;

public class Respository<TEntity, TEntityId> 
    where TEntity : Entity<TEntityId>
    where TEntityId : class
{
    private readonly CleanArchDbContext _dbContext;

    public Respository(CleanArchDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Delete(TEntity entity)
    {
        _dbContext.Set<TEntity>().Remove(entity);
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        return await _dbContext.Set<TEntity>().ToListAsync();
    }

    public async Task<TEntity?> GetByIdAsync(TEntityId id)
    {
        return await _dbContext.Set<TEntity>().SingleOrDefaultAsync(p => p.Id == id);
    }

    public IQueryable<TEntity> GetQueryable()
    {
       return  _dbContext.Set<TEntity>();
    }

    public void Add(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
    }

    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
    }
}