using System.Text.Json.Serialization;

namespace VariacaoAtivo.API.DTOs;

public class PriceVariationDataDto
{
    [JsonPropertyName("price_variation")] public IEnumerable<PriceVariationDto>? PriceVariationDto { get; set; }
}
