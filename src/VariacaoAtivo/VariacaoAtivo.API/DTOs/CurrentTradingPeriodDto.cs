namespace VariacaoAtivo.API.DTOs;

public class CurrentTradingPeriodDto
{
    public TradingPeriodDto Pre { get; set; }
    public TradingPeriodDto Regular { get; set; }
    public TradingPeriodDto Post { get; set; }
}
