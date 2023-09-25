// using CleanArch.Application.Data.Interfaces;
// using CleanArch.Domain.Orders;
// using Microsoft.EntityFrameworkCore;

// namespace CleanArch.Infrastructure.Persistence;

// internal sealed class OrderRespository : Respository<Order, OrderId>, IOrderRespository
// {
//     private readonly CleanArchDbContext _dbContext;
//     public OrderRespository(CleanArchDbContext dbContext) : base(dbContext)
//     {
//         _dbContext = dbContext;
//     }

//     public async Task<Order?> GetByIDAsync(OrderId id)
//     {
//         return await _dbContext.Orders.SingleOrDefaultAsync(o => o.Id == id);
//     }
// }