using VariacaoAtivo.API.DTOs;
using VariacaoAtivo.API.Interfaces;

namespace VariacaoAtivo.API.Services;

public class PriceVariationAggregator : IPriceVariationAggregator
{
    private readonly IDataService _dataService;
    public PriceVariationAggregator(IDataService dataService)
    {
        _dataService = dataService;
    }

    public async Task<PriceVariationDataDto?> GetVariation()
    {
        var pricesVariation = new List<PriceVariationDto>();
        var assets = await _dataService.GetAssetValues();
        if (assets is null) return new PriceVariationDataDto { PriceVariationDto = pricesVariation };

        pricesVariation.Add(new PriceVariationDto
        {
            Dia = 1,
            Data = assets[0].Date,
            Valor = assets[0].Value,
            VariacaoPrimeiraData = "-",
            VariacaoDMenos1 = "-"
        });

        for (int i = 1; i < assets.Count(); i++)
        {
            var priceVariation = new PriceVariationDto
            {
                Dia = i + 1,
                Data = assets[i].Date,
                Valor = assets[i].Value,
                VariacaoPrimeiraData = CalculatesVariationFirstValue(assets[0].Value, assets[i].Value),
                VariacaoDMenos1 = CalculatesVariationValue(assets[i - 1].Value, assets[i].Value)
            };

            pricesVariation.Add(priceVariation);
        }

        return new PriceVariationDataDto { PriceVariationDto = pricesVariation };
    }

    private static string CalculatesVariationFirstValue(decimal firstValue, decimal currentValue)
    {
        if (firstValue == 0 || currentValue == 0) return "-";

        var value = (currentValue - firstValue) * 100 / firstValue;

        return $"{String.Format("{0:0.##}", value)}%";
    }

    private static string CalculatesVariationValue(decimal beforeValue, decimal currentValue)
    {
        if (beforeValue == 0 || currentValue == 0) return "-";

        var value = (currentValue - beforeValue) * 100 / beforeValue;

        return $"{String.Format("{0:0.##}", value)}%";
    }
}
