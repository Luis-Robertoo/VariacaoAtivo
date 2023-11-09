using System.Text.Json.Serialization;

namespace VariacaoAtivo.API.DTOs;

public class MetaDto
{
    public string Currency { get; set; }
    [JsonPropertyName("symbol")] public string Symbol { get; set; }
    public string ExchangeName { get; set; }
    public string InstrumentType { get; set; }
    public long FirstTradeDate { get; set; }
    public long RegularMarketTime { get; set; }
    public int GmtOffset { get; set; }
    public string Timezone { get; set; }
    public string ExchangeTimezoneName { get; set; }
    public double RegularMarketPrice { get; set; }
    public double ChartPreviousClose { get; set; }
    public double PreviousClose { get; set; }
    public int Scale { get; set; }
    public int PriceHint { get; set; }
    public CurrentTradingPeriodDto CurrentTradingPeriod { get; set; }
    public List<List<long>> TradingPeriods { get; set; }
    public string DataGranularity { get; set; }
    public string Range { get; set; }
    public List<string> ValidRanges { get; set; }
}
