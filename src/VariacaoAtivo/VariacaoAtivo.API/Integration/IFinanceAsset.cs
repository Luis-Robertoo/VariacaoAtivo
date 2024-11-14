using Refit;
using VariacaoAtivo.API.DTOs;

namespace VariacaoAtivo.API.Integration;

public interface IFinanceAsset
{
    [Get("/v8/finance/chart/EMBR3.SA?interval=1d&range=30d")]
    Task<ChartDataDto> ReturnDataAssets();

    [Get("/v8/finance/chart/{asset}?interval=1d&range={range}d")]
    Task<ApiResponse<ChartDataDto>> ReturnDataAssetsFilter([Query] string asset, string range);
}
