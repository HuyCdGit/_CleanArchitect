namespace CleanArch.Application.Data.Interfaces;

public interface IUnitOfWork 
{
    public IProductRespository Products {get;}

    public ICustomerRespository Customers {get;}

    Task SaveChangeAsync(CancellationToken cancellationToken);
}