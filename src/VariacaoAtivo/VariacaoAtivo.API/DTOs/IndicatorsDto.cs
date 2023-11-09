using System.Text.Json.Serialization;

namespace VariacaoAtivo.API.DTOs;

public class IndicatorsDto
{
    [JsonPropertyName("quote")] public List<QuoteDto> Quote { get; set; }
}
