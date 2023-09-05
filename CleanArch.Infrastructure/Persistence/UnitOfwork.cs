using CleanArch.Application.Data.Interfaces;
using CleanArch.Domain.Customers;

namespace CleanArch.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly CleanArchDbContext _dbContext;

    public IProductRespository Products { get; }
    public ICustomerRespository Customers {get;}
    public UnitOfWork(CleanArchDbContext dbContext)
    {
        _dbContext = dbContext;
        Products = new ProductRespository(dbContext);
        Customers = new CustomerRespository(dbContext);
    }

    public async Task SaveChangeAsync(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
