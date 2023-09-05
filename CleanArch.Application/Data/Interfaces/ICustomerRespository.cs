using CleanArch.Domain.Customers;
using CleanArch.Domain.Products;

namespace CleanArch.Application.Data.Interfaces;

public interface ICustomerRespository : IRespository<Customer, CustomerId>
{

}