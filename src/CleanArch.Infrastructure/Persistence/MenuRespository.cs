using CleanArch.Application.Data.Interfaces;
using CleanArch.Domain.Menu;
using CleanArch.Domain.Menu.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.Infrastructure.Persistence;

internal sealed class MenuRespository : Respository<Menu, MenuId>, IMenuRespository
{
    private readonly CleanArchDbContext _dbContext;
    private static readonly List<Menu> _menu = new();
    public MenuRespository(CleanArchDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Menu?> GetByIDAsync(MenuId id)
    {
        return await _dbContext.Menus.SingleOrDefaultAsync(o => o.Id == id);
    }

    public async Task AddAysnc(Menu menu, CancellationToken cancellationToken)
    {
        await _dbContext.Menus.AddAsync(menu);
        await _dbContext.SaveChangeAsync(cancellationToken);
    }
}