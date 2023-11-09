using System.Text.Json.Serialization;

namespace VariacaoAtivo.API.DTOs;

public class ResultDto
{
    [JsonPropertyName("meta")] public MetaDto Meta { get; set; }
    [JsonPropertyName("timestamp")] public List<long> Timestamp { get; set; }
    [JsonPropertyName("indicators")] public IndicatorsDto Indicators { get; set; }
}
