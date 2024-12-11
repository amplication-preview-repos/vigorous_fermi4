using Microsoft.AspNetCore.Mvc;
using .APIs;
using .APIs.Dtos;
using .APIs.Errors;
using .APIs.Common;

namespace .APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class MarketingProductsControllerBase : ControllerBase
{
    protected readonly IMarketingProductsService _service;
    public MarketingProductsControllerBase(IMarketingProductsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one MarketingProduct
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<MarketingProduct>> CreateMarketingProduct(MarketingProductCreateInput input)
    {
        var marketingProduct = await _service.CreateMarketingProduct(input);

        return CreatedAtAction(nameof(MarketingProduct), new { id = marketingProduct.Id }, marketingProduct);
    }

    /// <summary>
    /// Delete one MarketingProduct
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteMarketingProduct([FromRoute()]
    MarketingProductWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteMarketingProduct(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many MarketingProducts
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<MarketingProduct>>> MarketingProducts([FromQuery()]
    MarketingProductFindManyArgs filter)
    {
        return Ok(await _service.MarketingProducts(filter));
    }

    /// <summary>
    /// Meta data about MarketingProduct records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> MarketingProductsMeta([FromQuery()]
    MarketingProductFindManyArgs filter)
    {
        return Ok(await _service.MarketingProductsMeta(filter));
    }

    /// <summary>
    /// Get one MarketingProduct
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<MarketingProduct>> MarketingProduct([FromRoute()]
    MarketingProductWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.MarketingProduct(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one MarketingProduct
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateMarketingProduct([FromRoute()]
    MarketingProductWhereUniqueInput uniqueId, [FromQuery()]
    MarketingProductUpdateInput marketingProductUpdateDto)
    {
        try
        {
            await _service.UpdateMarketingProduct(uniqueId, marketingProductUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a DigitalHuman record for MarketingProduct
    /// </summary>
    [HttpGet("{Id}/digitalHuman")]
    public async Task<ActionResult<List<DigitalHuman>>> GetDigitalHuman([FromRoute()]
    MarketingProductWhereUniqueInput uniqueId)
    {
        var digitalHuman = await _service.GetDigitalHuman(uniqueId);
        return Ok(digitalHuman);
    }

}
