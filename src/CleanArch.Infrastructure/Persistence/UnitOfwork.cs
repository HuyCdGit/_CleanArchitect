using CleanArch.Application.Data.Interfaces;

namespace CleanArch.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly CleanArchDbContext _dbContext;

    // public IProductRespository Products { get; }
    // public ICustomerRespository Customers {get;}
    // public IOrderRespository Orders {get;}
    public IMenuRespository Menus {get;}

    public UnitOfWork(CleanArchDbContext dbContext)
    {
        _dbContext = dbContext;
        // Products = new ProductRespository(dbContext);
        // Customers = new CustomerRespository(dbContext);
        // Orders = new OrderRespository(dbContext);
        Menus = new MenuRespository(dbContext);
    }

    public async Task SaveChangeAsync(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
