using VariacaoAtivo.API.DTOs;

namespace VariacaoAtivo.API.Interfaces;

public interface IPriceVariationAggregator
{
    Task<PriceVariationDataDto?> GetVariation();
}
