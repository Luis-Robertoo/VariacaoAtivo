using System.Linq.Expressions;
using VariacaoAtivo.API.Entities;

namespace VariacaoAtivo.API.Interfaces;

public interface IAssetValueRepositorie
{
    Task<AssetValue?> Create(AssetValue entity);
    Task<int?> CreateMany(IEnumerable<AssetValue> entities);
    Task<IEnumerable<AssetValue>?> GetByQuery(Expression<Func<AssetValue, bool>> expression);
    Task<AssetValue?> GetLastDate();
    Task<IEnumerable<AssetValue>?> GetLastestDates(int quantity = 30);
}
