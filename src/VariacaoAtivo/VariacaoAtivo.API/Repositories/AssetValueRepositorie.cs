using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using VariacaoAtivo.API.Entities;
using VariacaoAtivo.API.Interfaces;

namespace VariacaoAtivo.API.Repositories;

public class AssetValueRepositorie : IAssetValueRepositorie
{
    private readonly DataBaseContext _context;
    public AssetValueRepositorie(DataBaseContext context)
    {
        _context = context;
    }

    public async Task<AssetValue?> Create(AssetValue entity)
    {
        var result = await _context.AssetValue.AddAsync(entity);

        var items = _context.SaveChanges();
        if (items < 1) return null;

        return result.Entity;
    }

    public async Task<int?> CreateMany(IEnumerable<AssetValue> entities)
    {
        await _context.AssetValue.AddRangeAsync(entities);
        var items = _context.SaveChanges();
        if (items < 1) return null;
        return items;
    }

    public async Task<IEnumerable<AssetValue>?> GetByQuery(Expression<Func<AssetValue, bool>> expression)
    {
        var result = await _context.AssetValue.Where(expression).ToListAsync();
        return result;
    }

    public async Task<AssetValue?> GetLastDate()
    {
        var result = await _context.AssetValue.OrderByDescending(av => av.Date).FirstOrDefaultAsync();
        return result;
    }

    public async Task<IEnumerable<AssetValue>?> GetLastestDates(int quantity = 30)
    {
        var result = await _context.AssetValue.OrderByDescending(av => av.Date).Take(quantity).ToListAsync();
        return result;
    }
}
