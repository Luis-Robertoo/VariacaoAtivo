﻿namespace VariacaoAtivo.API.DTOs;

public class TradingPeriodDto
{
    public string Timezone { get; set; }
    public long Start { get; set; }
    public long End { get; set; }
    public int GmtOffset { get; set; }
}
