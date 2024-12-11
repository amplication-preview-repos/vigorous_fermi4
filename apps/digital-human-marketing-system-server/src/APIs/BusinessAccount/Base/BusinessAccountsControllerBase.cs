using Microsoft.AspNetCore.Mvc;
using .APIs;
using .APIs.Dtos;
using .APIs.Errors;
using .APIs.Common;

namespace .APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class BusinessAccountsControllerBase : ControllerBase
{
    protected readonly IBusinessAccountsService _service;
    public BusinessAccountsControllerBase(IBusinessAccountsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one BusinessAccount
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<BusinessAccount>> CreateBusinessAccount(BusinessAccountCreateInput input)
    {
        var businessAccount = await _service.CreateBusinessAccount(input);

        return CreatedAtAction(nameof(BusinessAccount), new { id = businessAccount.Id }, businessAccount);
    }

    /// <summary>
    /// Delete one BusinessAccount
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteBusinessAccount([FromRoute()]
    BusinessAccountWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteBusinessAccount(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many BusinessAccounts
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<BusinessAccount>>> BusinessAccounts([FromQuery()]
    BusinessAccountFindManyArgs filter)
    {
        return Ok(await _service.BusinessAccounts(filter));
    }

    /// <summary>
    /// Meta data about BusinessAccount records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> BusinessAccountsMeta([FromQuery()]
    BusinessAccountFindManyArgs filter)
    {
        return Ok(await _service.BusinessAccountsMeta(filter));
    }

    /// <summary>
    /// Get one BusinessAccount
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<BusinessAccount>> BusinessAccount([FromRoute()]
    BusinessAccountWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.BusinessAccount(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one BusinessAccount
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateBusinessAccount([FromRoute()]
    BusinessAccountWhereUniqueInput uniqueId, [FromQuery()]
    BusinessAccountUpdateInput businessAccountUpdateDto)
    {
        try
        {
            await _service.UpdateBusinessAccount(uniqueId, businessAccountUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Connect multiple DigitalHumen records to BusinessAccount
    /// </summary>
    [HttpPost("{Id}/digitalHumen")]
    public async Task<ActionResult> ConnectDigitalHumen([FromRoute()]
    BusinessAccountWhereUniqueInput uniqueId, [FromQuery()]
    DigitalHumanWhereUniqueInput[] digitalHumenId)
    {
        try
        {
            await _service.ConnectDigitalHumen(uniqueId, digitalHumenId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Disconnect multiple DigitalHumen records from BusinessAccount
    /// </summary>
    [HttpDelete("{Id}/digitalHumen")]
    public async Task<ActionResult> DisconnectDigitalHumen([FromRoute()]
    BusinessAccountWhereUniqueInput uniqueId, [FromBody()]
    DigitalHumanWhereUniqueInput[] digitalHumenId)
    {
        try
        {
            await _service.DisconnectDigitalHumen(uniqueId, digitalHumenId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find multiple DigitalHumen records for BusinessAccount
    /// </summary>
    [HttpGet("{Id}/digitalHumen")]
    public async Task<ActionResult<List<DigitalHuman>>> FindDigitalHumen([FromRoute()]
    BusinessAccountWhereUniqueInput uniqueId, [FromQuery()]
    DigitalHumanFindManyArgs filter)
    {
        try
        {
            return Ok(await _service.FindDigitalHumen(uniqueId, filter));
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update multiple DigitalHumen records for BusinessAccount
    /// </summary>
    [HttpPatch("{Id}/digitalHumen")]
    public async Task<ActionResult> UpdateDigitalHumen([FromRoute()]
    BusinessAccountWhereUniqueInput uniqueId, [FromBody()]
    DigitalHumanWhereUniqueInput[] digitalHumenId)
    {
        try
        {
            await _service.UpdateDigitalHumen(uniqueId, digitalHumenId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

}
