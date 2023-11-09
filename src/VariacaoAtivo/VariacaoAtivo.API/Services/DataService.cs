using VariacaoAtivo.API.DTOs;
using VariacaoAtivo.API.Entities;
using VariacaoAtivo.API.Interfaces;

namespace VariacaoAtivo.API.Services;

public class DataService : IDataService
{
    private readonly IGetDataApiService _getDataService;
    private readonly IAssetValueRepositorie _assetValueRepositorie;
    public DataService(IGetDataApiService getDataService, IAssetValueRepositorie assetValueRepositorie)
    {
        _getDataService = getDataService;
        _assetValueRepositorie = assetValueRepositorie;
    }

    public async Task<List<AssetValue>?> GetAssetValues()
    {
        await CheckLatestAuctions();
        var result = await _assetValueRepositorie.GetLastestDates();
        var order = result?.OrderBy(r => r.Date).ToList();
        return order;
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
