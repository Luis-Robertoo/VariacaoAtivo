using Microsoft.AspNetCore.Mvc;
using VariacaoAtivo.API.Interfaces;

namespace VariacaoAtivo.API.Controllers;

[ApiController]
[Route("[controller]")]
public class VariacaoAtivoController : ControllerBase
{
    private readonly IPriceVariationAggregator _priceVariationAggregator;

    public VariacaoAtivoController(IPriceVariationAggregator priceVariationAggregator)
    {
        _priceVariationAggregator = priceVariationAggregator;
    }

    [HttpGet()]
    public async Task<ActionResult> Get()
    {
        var result = await _priceVariationAggregator.GetVariation();
        return Ok(result);
    }
}
