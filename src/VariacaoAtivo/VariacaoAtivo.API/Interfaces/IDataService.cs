using VariacaoAtivo.API.Entities;

namespace VariacaoAtivo.API.Interfaces;

public interface IDataService
{
    Task<List<AssetValue>?> GetAssetValues();
}
