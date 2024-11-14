using VariacaoAtivo.API.Entities;

namespace VariacaoAtivo.API.Interfaces;

public interface IDataService
{
    Task<List<AssetValue>?> GetAssetValues();
    Task<List<AssetValue>?> GetAssetValues(string? ativo, string? periodo = "30");
}
