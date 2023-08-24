namespace CleanArch.Domain.Customers;

public interface ICustomerRespository
{
    Task<Customer?> GetCustomerByID(CustomerId id);
}