using System.Text.Json.Serialization;

namespace VariacaoAtivo.API.DTOs;

public class QuoteDto
{
    public List<long?> Volume { get; set; }
    [JsonPropertyName("open")] public List<double?> Open { get; set; }
    public List<double?> Close { get; set; }
    public List<double?> High { get; set; }
    public List<double?> Low { get; set; }
}
