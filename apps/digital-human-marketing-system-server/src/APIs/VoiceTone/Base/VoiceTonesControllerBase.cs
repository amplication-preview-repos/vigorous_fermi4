using Microsoft.AspNetCore.Mvc;
using .APIs;
using .APIs.Dtos;
using .APIs.Errors;
using .APIs.Common;

namespace .APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class VoiceTonesControllerBase : ControllerBase
{
    protected readonly IVoiceTonesService _service;
    public VoiceTonesControllerBase(IVoiceTonesService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one VoiceTone
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<VoiceTone>> CreateVoiceTone(VoiceToneCreateInput input)
    {
        var voiceTone = await _service.CreateVoiceTone(input);

        return CreatedAtAction(nameof(VoiceTone), new { id = voiceTone.Id }, voiceTone);
    }

    /// <summary>
    /// Delete one VoiceTone
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteVoiceTone([FromRoute()]
    VoiceToneWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteVoiceTone(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many VoiceTones
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<VoiceTone>>> VoiceTones([FromQuery()]
    VoiceToneFindManyArgs filter)
    {
        return Ok(await _service.VoiceTones(filter));
    }

    /// <summary>
    /// Meta data about VoiceTone records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> VoiceTonesMeta([FromQuery()]
    VoiceToneFindManyArgs filter)
    {
        return Ok(await _service.VoiceTonesMeta(filter));
    }

    /// <summary>
    /// Get one VoiceTone
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<VoiceTone>> VoiceTone([FromRoute()]
    VoiceToneWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.VoiceTone(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one VoiceTone
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateVoiceTone([FromRoute()]
    VoiceToneWhereUniqueInput uniqueId, [FromQuery()]
    VoiceToneUpdateInput voiceToneUpdateDto)
    {
        try
        {
            await _service.UpdateVoiceTone(uniqueId, voiceToneUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

}
