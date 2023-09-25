namespace CleanArch.Application.Data.Interfaces;

public interface IUnitOfWork
{
    // public IProductRespository Products {get;}

    // public ICustomerRespository Customers {get;}

    // public IOrderRespository Orders {get;}
    public IMenuRespository Menus { get; }

    Task SaveChangeAsync(CancellationToken cancellationToken);
}