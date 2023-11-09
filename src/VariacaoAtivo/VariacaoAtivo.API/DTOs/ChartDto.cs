using System.Text.Json.Serialization;

namespace VariacaoAtivo.API.DTOs;

public class ChartDto
{
    [JsonPropertyName("result")] public List<ResultDto> Result { get; set; }
    [JsonPropertyName("error")] public object Error { get; set; }
}
