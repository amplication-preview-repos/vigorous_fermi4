using Microsoft.AspNetCore.Mvc;
using .APIs;
using .APIs.Dtos;
using .APIs.Errors;
using .APIs.Common;

namespace .APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class DigitalHumanStatsItemsControllerBase : ControllerBase
{
    protected readonly IDigitalHumanStatsItemsService _service;
    public DigitalHumanStatsItemsControllerBase(IDigitalHumanStatsItemsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one DigitalHumanStats
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<DigitalHumanStats>> CreateDigitalHumanStats(DigitalHumanStatsCreateInput input)
    {
        var digitalHumanStats = await _service.CreateDigitalHumanStats(input);

        return CreatedAtAction(nameof(DigitalHumanStats), new { id = digitalHumanStats.Id }, digitalHumanStats);
    }

    /// <summary>
    /// Delete one DigitalHumanStats
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteDigitalHumanStats([FromRoute()]
    DigitalHumanStatsWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteDigitalHumanStats(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many DigitalHumanStatsItems
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<DigitalHumanStats>>> DigitalHumanStatsItems([FromQuery()]
    DigitalHumanStatsFindManyArgs filter)
    {
        return Ok(await _service.DigitalHumanStatsItems(filter));
    }

    /// <summary>
    /// Meta data about DigitalHumanStats records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> DigitalHumanStatsItemsMeta([FromQuery()]
    DigitalHumanStatsFindManyArgs filter)
    {
        return Ok(await _service.DigitalHumanStatsItemsMeta(filter));
    }

    /// <summary>
    /// Get one DigitalHumanStats
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<DigitalHumanStats>> DigitalHumanStats([FromRoute()]
    DigitalHumanStatsWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.DigitalHumanStats(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one DigitalHumanStats
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateDigitalHumanStats([FromRoute()]
    DigitalHumanStatsWhereUniqueInput uniqueId, [FromQuery()]
    DigitalHumanStatsUpdateInput digitalHumanStatsUpdateDto)
    {
        try
        {
            await _service.UpdateDigitalHumanStats(uniqueId, digitalHumanStatsUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a DigitalHuman record for DigitalHumanStats
    /// </summary>
    [HttpGet("{Id}/digitalHuman")]
    public async Task<ActionResult<List<DigitalHuman>>> GetDigitalHuman([FromRoute()]
    DigitalHumanStatsWhereUniqueInput uniqueId)
    {
        var digitalHuman = await _service.GetDigitalHuman(uniqueId);
        return Ok(digitalHuman);
    }

}
