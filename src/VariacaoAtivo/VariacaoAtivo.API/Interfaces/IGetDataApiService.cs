using VariacaoAtivo.API.DTOs;

namespace VariacaoAtivo.API.Interfaces;

public interface IGetDataApiService
{
    Task<ChartDataDto>? GetChartData();
}
