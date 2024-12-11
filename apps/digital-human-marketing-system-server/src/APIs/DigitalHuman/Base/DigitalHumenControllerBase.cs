using Microsoft.AspNetCore.Mvc;
using .APIs;
using .APIs.Dtos;
using .APIs.Errors;
using .APIs.Common;

namespace .APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class DigitalHumenControllerBase : ControllerBase
{
    protected readonly IDigitalHumenService _service;
    public DigitalHumenControllerBase(IDigitalHumenService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one DigitalHuman
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<DigitalHuman>> CreateDigitalHuman(DigitalHumanCreateInput input)
    {
        var digitalHuman = await _service.CreateDigitalHuman(input);

        return CreatedAtAction(nameof(DigitalHuman), new { id = digitalHuman.Id }, digitalHuman);
    }

    /// <summary>
    /// Delete one DigitalHuman
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteDigitalHuman([FromRoute()]
    DigitalHumanWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteDigitalHuman(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many DigitalHumen
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<DigitalHuman>>> DigitalHumen([FromQuery()]
    DigitalHumanFindManyArgs filter)
    {
        return Ok(await _service.DigitalHumen(filter));
    }

    /// <summary>
    /// Meta data about DigitalHuman records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> DigitalHumenMeta([FromQuery()]
    DigitalHumanFindManyArgs filter)
    {
        return Ok(await _service.DigitalHumenMeta(filter));
    }

    /// <summary>
    /// Get one DigitalHuman
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<DigitalHuman>> DigitalHuman([FromRoute()]
    DigitalHumanWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.DigitalHuman(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one DigitalHuman
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateDigitalHuman([FromRoute()]
    DigitalHumanWhereUniqueInput uniqueId, [FromQuery()]
    DigitalHumanUpdateInput digitalHumanUpdateDto)
    {
        try
        {
            await _service.UpdateDigitalHuman(uniqueId, digitalHumanUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a BusinessAccount record for DigitalHuman
    /// </summary>
    [HttpGet("{Id}/businessAccount")]
    public async Task<ActionResult<List<BusinessAccount>>> GetBusinessAccount([FromRoute()]
    DigitalHumanWhereUniqueInput uniqueId)
    {
        var businessAccount = await _service.GetBusinessAccount(uniqueId);
        return Ok(businessAccount);
    }

    /// <summary>
    /// Connect multiple DigitalHumanKnowledgeBases records to DigitalHuman
    /// </summary>
    [HttpPost("{Id}/digitalHumanKnowledgeBases")]
    public async Task<ActionResult> ConnectDigitalHumanKnowledgeBases([FromRoute()]
    DigitalHumanWhereUniqueInput uniqueId, [FromQuery()]
    DigitalHumanKnowledgeBaseWhereUniqueInput[] digitalHumanKnowledgeBasesId)
    {
        try
        {
            await _service.ConnectDigitalHumanKnowledgeBases(uniqueId, digitalHumanKnowledgeBasesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple DigitalHumanKnowledgeBases records from DigitalHuman
    /// </summary>
    [HttpDelete("{Id}/digitalHumanKnowledgeBases")]
    public async Task<ActionResult> DisconnectDigitalHumanKnowledgeBases([FromRoute()]
    DigitalHumanWhereUniqueInput uniqueId, [FromBody()]
    DigitalHumanKnowledgeBaseWhereUniqueInput[] digitalHumanKnowledgeBasesId)
    {
        try
        {
            await _service.DisconnectDigitalHumanKnowledgeBases(uniqueId, digitalHumanKnowledgeBasesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple DigitalHumanKnowledgeBases records for DigitalHuman
    /// </summary>
    [HttpGet("{Id}/digitalHumanKnowledgeBases")]
    public async Task<ActionResult<List<DigitalHumanKnowledgeBase>>> FindDigitalHumanKnowledgeBases([FromRoute()]
    DigitalHumanWhereUniqueInput uniqueId, [FromQuery()]
    DigitalHumanKnowledgeBaseFindManyArgs filter)
    {
        try
        {
            return Ok(await _service.FindDigitalHumanKnowledgeBases(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple DigitalHumanKnowledgeBases records for DigitalHuman
    /// </summary>
    [HttpPatch("{Id}/digitalHumanKnowledgeBases")]
    public async Task<ActionResult> UpdateDigitalHumanKnowledgeBases([FromRoute()]
    DigitalHumanWhereUniqueInput uniqueId, [FromBody()]
    DigitalHumanKnowledgeBaseWhereUniqueInput[] digitalHumanKnowledgeBasesId)
    {
        try
        {
            await _service.UpdateDigitalHumanKnowledgeBases(uniqueId, digitalHumanKnowledgeBasesId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple DigitalHumanStatsItems records to DigitalHuman
    /// </summary>
    [HttpPost("{Id}/digitalHumanStatsItems")]
    public async Task<ActionResult> ConnectDigitalHumanStatsItems([FromRoute()]
    DigitalHumanWhereUniqueInput uniqueId, [FromQuery()]
    DigitalHumanStatsWhereUniqueInput[] digitalHumanStatsItemsId)
    {
        try
        {
            await _service.ConnectDigitalHumanStatsItems(uniqueId, digitalHumanStatsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple DigitalHumanStatsItems records from DigitalHuman
    /// </summary>
    [HttpDelete("{Id}/digitalHumanStatsItems")]
    public async Task<ActionResult> DisconnectDigitalHumanStatsItems([FromRoute()]
    DigitalHumanWhereUniqueInput uniqueId, [FromBody()]
    DigitalHumanStatsWhereUniqueInput[] digitalHumanStatsItemsId)
    {
        try
        {
            await _service.DisconnectDigitalHumanStatsItems(uniqueId, digitalHumanStatsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple DigitalHumanStatsItems records for DigitalHuman
    /// </summary>
    [HttpGet("{Id}/digitalHumanStatsItems")]
    public async Task<ActionResult<List<DigitalHumanStats>>> FindDigitalHumanStatsItems([FromRoute()]
    DigitalHumanWhereUniqueInput uniqueId, [FromQuery()]
    DigitalHumanStatsFindManyArgs filter)
    {
        try
        {
            return Ok(await _service.FindDigitalHumanStatsItems(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple DigitalHumanStatsItems records for DigitalHuman
    /// </summary>
    [HttpPatch("{Id}/digitalHumanStatsItems")]
    public async Task<ActionResult> UpdateDigitalHumanStatsItems([FromRoute()]
    DigitalHumanWhereUniqueInput uniqueId, [FromBody()]
    DigitalHumanStatsWhereUniqueInput[] digitalHumanStatsItemsId)
    {
        try
        {
            await _service.UpdateDigitalHumanStatsItems(uniqueId, digitalHumanStatsItemsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple MarketingProducts records to DigitalHuman
    /// </summary>
    [HttpPost("{Id}/marketingProducts")]
    public async Task<ActionResult> ConnectMarketingProducts([FromRoute()]
    DigitalHumanWhereUniqueInput uniqueId, [FromQuery()]
    MarketingProductWhereUniqueInput[] marketingProductsId)
    {
        try
        {
            await _service.ConnectMarketingProducts(uniqueId, marketingProductsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple MarketingProducts records from DigitalHuman
    /// </summary>
    [HttpDelete("{Id}/marketingProducts")]
    public async Task<ActionResult> DisconnectMarketingProducts([FromRoute()]
    DigitalHumanWhereUniqueInput uniqueId, [FromBody()]
    MarketingProductWhereUniqueInput[] marketingProductsId)
    {
        try
        {
            await _service.DisconnectMarketingProducts(uniqueId, marketingProductsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple MarketingProducts records for DigitalHuman
    /// </summary>
    [HttpGet("{Id}/marketingProducts")]
    public async Task<ActionResult<List<MarketingProduct>>> FindMarketingProducts([FromRoute()]
    DigitalHumanWhereUniqueInput uniqueId, [FromQuery()]
    MarketingProductFindManyArgs filter)
    {
        try
        {
            return Ok(await _service.FindMarketingProducts(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple MarketingProducts records for DigitalHuman
    /// </summary>
    [HttpPatch("{Id}/marketingProducts")]
    public async Task<ActionResult> UpdateMarketingProducts([FromRoute()]
    DigitalHumanWhereUniqueInput uniqueId, [FromBody()]
    MarketingProductWhereUniqueInput[] marketingProductsId)
    {
        try
        {
            await _service.UpdateMarketingProducts(uniqueId, marketingProductsId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

}
