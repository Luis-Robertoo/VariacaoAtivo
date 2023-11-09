using System.Text.Json.Serialization;

namespace VariacaoAtivo.API.DTOs;

public class PriceVariationDto
{
    [JsonPropertyName("dia")] public int Dia { get; set; }
    [JsonPropertyName("data")] public DateTime Data { get; set; }
    [JsonPropertyName("valor")] public decimal Valor { get; set; }
    [JsonPropertyName("variacao_d1")] public string VariacaoDMenos1 { get; set; }
    [JsonPropertyName("variacao_primeira_data")] public string VariacaoPrimeiraData { get; set; }
}
