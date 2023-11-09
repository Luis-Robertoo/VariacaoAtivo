using System.Text.Json;
using VariacaoAtivo.API.DTOs;
using VariacaoAtivo.API.Interfaces;

namespace VariacaoAtivo.API.Services;

public class GetDataApiService : IGetDataApiService
{
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly string _urlAtivo;

    public GetDataApiService(IConfiguration configuration)
    {
        _configuration = configuration;
        _httpClient = new HttpClient();
        _urlAtivo = _configuration.GetValue<string>("UrlAtivo");
    }

    public async Task<ChartDataDto>? GetChartData()
    {
        var response = await _httpClient.GetAsync(_urlAtivo);

        if (!response.IsSuccessStatusCode)
            return null;

        var body = await response.Content.ReadAsStringAsync();
        var chart = JsonSerializer.Deserialize<ChartDataDto>(body);
        return chart;
    }

}
