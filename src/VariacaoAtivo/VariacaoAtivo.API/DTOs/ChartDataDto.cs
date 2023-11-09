using System.Text.Json.Serialization;

namespace VariacaoAtivo.API.DTOs;

public class ChartDataDto
{
    [JsonPropertyName("chart")] public ChartDto Chart { get; set; }
}
