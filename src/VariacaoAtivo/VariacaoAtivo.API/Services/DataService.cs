using VariacaoAtivo.API.DTOs;
using VariacaoAtivo.API.Entities;
using VariacaoAtivo.API.Integration;
using VariacaoAtivo.API.Interfaces;

namespace VariacaoAtivo.API.Services;

public class DataService : IDataService
{
    private readonly IGetDataApiService _getDataService;
    private readonly IAssetValueRepositorie _assetValueRepositorie;
    private readonly IFinanceAsset _financeAsset;
    public DataService(IGetDataApiService getDataService, IAssetValueRepositorie assetValueRepositorie, IFinanceAsset financeAsset)
    {
        _getDataService = getDataService;
        _assetValueRepositorie = assetValueRepositorie;
        _financeAsset = financeAsset;
    }

    public async Task<List<AssetValue>?> GetAssetValues()
    {
        try
        {
            await CheckLatestAuctions();
            var data = await _assetValueRepositorie.GetLastestDates();
            var result = data?.OrderBy(r => r.Date).ToList();
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao acessar o banco de Dados: {ex.Message}");

            var data = await _financeAsset.ReturnDataAssets();
            var result = CreateListAssetsValues(data).OrderBy(r => r.Date).ToList();
            return result;
        }
    }

    public async Task<List<AssetValue>?> GetAssetValues(string? ativo, string periodo)
    {
        var data = await _financeAsset.ReturnDataAssetsFilter(ativo, periodo);
        if (!data.IsSuccessStatusCode) return null;

        var result = CreateListAssetsValues(data.Content).OrderBy(r => r.Date).ToList();
        return result;
    }


    private async Task CheckLatestAuctions()
    {
        var assetValue = await _assetValueRepositorie.GetLastDate();
        if (assetValue is null || assetValue.Date < DateTime.Now.AddDays(-1))
        {
            var data = await _getDataService.GetChartData();
            var assets = CreateListAssetsValues(data);
            await _assetValueRepositorie.CreateMany(assets);
        }
    }

    private static IEnumerable<AssetValue> CreateListAssetsValues(ChartDataDto dto)
    {
        var assetsValues = new List<AssetValue>();
        var name = dto.Chart.Result.FirstOrDefault().Meta.Symbol;
        var timestamps = dto.Chart.Result.FirstOrDefault().Timestamp;
        var values = dto.Chart.Result.FirstOrDefault().Indicators.Quote.FirstOrDefault().Open;

        for (int i = 0; i < timestamps.Count; i++)
        {
            var dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timestamps[i]);
            assetsValues.Add(new AssetValue { Date = dateTimeOffset.DateTime, Name = name, Value = Convert.ToDecimal(values[i]) });
        }

        return assetsValues;
    }
}
