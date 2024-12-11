using Microsoft.AspNetCore.Mvc;
using .APIs;
using .APIs.Dtos;
using .APIs.Errors;
using .APIs.Common;

namespace .APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class DigitalHumanKnowledgeBasesControllerBase : ControllerBase
{
    protected readonly IDigitalHumanKnowledgeBasesService _service;
    public DigitalHumanKnowledgeBasesControllerBase(IDigitalHumanKnowledgeBasesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one DigitalHumanKnowledgeBase
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<DigitalHumanKnowledgeBase>> CreateDigitalHumanKnowledgeBase(DigitalHumanKnowledgeBaseCreateInput input)
    {
        var digitalHumanKnowledgeBase = await _service.CreateDigitalHumanKnowledgeBase(input);

        return CreatedAtAction(nameof(DigitalHumanKnowledgeBase), new { id = digitalHumanKnowledgeBase.Id }, digitalHumanKnowledgeBase);
    }

    /// <summary>
    /// Delete one DigitalHumanKnowledgeBase
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteDigitalHumanKnowledgeBase([FromRoute()]
    DigitalHumanKnowledgeBaseWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteDigitalHumanKnowledgeBase(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many DigitalHumanKnowledgeBases
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<DigitalHumanKnowledgeBase>>> DigitalHumanKnowledgeBases([FromQuery()]
    DigitalHumanKnowledgeBaseFindManyArgs filter)
    {
        return Ok(await _service.DigitalHumanKnowledgeBases(filter));
    }

    /// <summary>
    /// Meta data about DigitalHumanKnowledgeBase records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> DigitalHumanKnowledgeBasesMeta([FromQuery()]
    DigitalHumanKnowledgeBaseFindManyArgs filter)
    {
        return Ok(await _service.DigitalHumanKnowledgeBasesMeta(filter));
    }

    /// <summary>
    /// Get one DigitalHumanKnowledgeBase
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<DigitalHumanKnowledgeBase>> DigitalHumanKnowledgeBase([FromRoute()]
    DigitalHumanKnowledgeBaseWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.DigitalHumanKnowledgeBase(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one DigitalHumanKnowledgeBase
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateDigitalHumanKnowledgeBase([FromRoute()]
    DigitalHumanKnowledgeBaseWhereUniqueInput uniqueId, [FromQuery()]
    DigitalHumanKnowledgeBaseUpdateInput digitalHumanKnowledgeBaseUpdateDto)
    {
        try
        {
            await _service.UpdateDigitalHumanKnowledgeBase(uniqueId, digitalHumanKnowledgeBaseUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Get a DigitalHuman record for DigitalHumanKnowledgeBase
    /// </summary>
    [HttpGet("{Id}/digitalHuman")]
    public async Task<ActionResult<List<DigitalHuman>>> GetDigitalHuman([FromRoute()]
    DigitalHumanKnowledgeBaseWhereUniqueInput uniqueId)
    {
        var digitalHuman = await _service.GetDigitalHuman(uniqueId);
        return Ok(digitalHuman);
    }

}
