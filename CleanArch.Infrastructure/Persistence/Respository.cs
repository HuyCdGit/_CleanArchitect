using CleanArch.Application;
using CleanArch.Application.Data;
using CleanArch.Application.Data.Interfaces;
using CleanArch.Application.Interfaces;
using CleanArch.Domain.Products;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Persistence;

public class Respository<TEntity> : IRespository<TEntity> where TEntity : class
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

    public async Task<TEntity?> GetByIdAsync(ProductId id)
    {
        return await _dbContext.Set<TEntity>().FindAsync(id);
    }

    public IQueryable<TEntity> GetQueryable()
    {
       return  _dbContext.Set<TEntity>();
    }

    public void Add(TEntity entity)
    {
        _dbContext.Set<TEntity>().Add(entity);
    }

    public Task<int> SaveChangeAsync(CancellationToken cancellationToken)
    {
        return _dbContext.SaveChangesAsync(cancellationToken);
    }

    public void Update(TEntity entity)
    {
        _dbContext.Set<TEntity>().Update(entity);
    }
}