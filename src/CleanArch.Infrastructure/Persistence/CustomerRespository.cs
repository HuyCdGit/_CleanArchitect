// using CleanArch.Application.Data.Interfaces;
// using CleanArch.Domain.Customers;
// using Microsoft.EntityFrameworkCore;

// namespace CleanArch.Infrastructure.Persistence;
// internal sealed class CustomerRespository : Respository<Customer, CustomerId>, ICustomerRespository
// {
//     private readonly CleanArchDbContext _dbContext;
//     public CustomerRespository(CleanArchDbContext dbContext) : base(dbContext)
//     {
//         _dbContext = dbContext;
//     }
//     public async Task<Customer?> GetByIDAsync(CustomerId id)
//     {
//         return await _dbContext.Customers.SingleOrDefaultAsync(p => p.Id == id);
//     }

//     //Có thể Override phương thức (Virtual)
//     // public async Task<Product?> GetByIdAsync(ProductId entity)
//     // {
//     //     return  await _dbContext.Products.FindAsync(entity);
//     // }
// }