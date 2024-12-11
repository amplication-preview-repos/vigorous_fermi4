using .APIs;
using .Infrastructure;
using .APIs.Dtos;
using .Infrastructure.Models;
using .APIs.Errors;
using .APIs.Extensions;
using .APIs.Common;
using Microsoft.EntityFrameworkCore;

namespace .APIs;

public abstract class DigitalHumanKnowledgeBasesServiceBase : IDigitalHumanKnowledgeBasesService
{
    protected readonly DbContext _context;
    public DigitalHumanKnowledgeBasesServiceBase(DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one DigitalHumanKnowledgeBase
    /// </summary>
    public async Task<DigitalHumanKnowledgeBase> CreateDigitalHumanKnowledgeBase(DigitalHumanKnowledgeBaseCreateInput createDto)
    {
        var digitalHumanKnowledgeBase = new DigitalHumanKnowledgeBaseDbModel
        {
            CreatedAt = createDto.CreatedAt,
            DocumentLink = createDto.DocumentLink,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            digitalHumanKnowledgeBase.Id = createDto.Id;
        }
        if (createDto.DigitalHuman != null)
        {
            digitalHumanKnowledgeBase.DigitalHuman = await _context
                .DigitalHumen.Where(digitalHuman => createDto.DigitalHuman.Id == digitalHuman.Id)
                .FirstOrDefaultAsync();
        }

        _context.DigitalHumanKnowledgeBases.Add(digitalHumanKnowledgeBase);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<DigitalHumanKnowledgeBaseDbModel>(digitalHumanKnowledgeBase.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one DigitalHumanKnowledgeBase
    /// </summary>
    public async Task DeleteDigitalHumanKnowledgeBase(DigitalHumanKnowledgeBaseWhereUniqueInput uniqueId)
    {
        var digitalHumanKnowledgeBase = await _context.DigitalHumanKnowledgeBases.FindAsync(uniqueId.Id);
        if (digitalHumanKnowledgeBase == null)
        {
            throw new NotFoundException();
        }

        _context.DigitalHumanKnowledgeBases.Remove(digitalHumanKnowledgeBase);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many DigitalHumanKnowledgeBases
    /// </summary>
    public async Task<List<DigitalHumanKnowledgeBase>> DigitalHumanKnowledgeBases(DigitalHumanKnowledgeBaseFindManyArgs findManyArgs)
    {
        var digitalHumanKnowledgeBases = await _context
              .DigitalHumanKnowledgeBases
      .Include(x => x.DigitalHuman)
      .ApplyWhere(findManyArgs.Where)
      .ApplySkip(findManyArgs.Skip)
      .ApplyTake(findManyArgs.Take)
      .ApplyOrderBy(findManyArgs.SortBy)
      .ToListAsync();
        return digitalHumanKnowledgeBases.ConvertAll(digitalHumanKnowledgeBase => digitalHumanKnowledgeBase.ToDto());
    }

    /// <summary>
    /// Meta data about DigitalHumanKnowledgeBase records
    /// </summary>
    public async Task<MetadataDto> DigitalHumanKnowledgeBasesMeta(DigitalHumanKnowledgeBaseFindManyArgs findManyArgs)
    {

        var count = await _context
    .DigitalHumanKnowledgeBases
    .ApplyWhere(findManyArgs.Where)
    .CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one DigitalHumanKnowledgeBase
    /// </summary>
    public async Task<DigitalHumanKnowledgeBase> DigitalHumanKnowledgeBase(DigitalHumanKnowledgeBaseWhereUniqueInput uniqueId)
    {
        var digitalHumanKnowledgeBases = await this.DigitalHumanKnowledgeBases(
                  new DigitalHumanKnowledgeBaseFindManyArgs { Where = new DigitalHumanKnowledgeBaseWhereInput { Id = uniqueId.Id } }
      );
        var digitalHumanKnowledgeBase = digitalHumanKnowledgeBases.FirstOrDefault();
        if (digitalHumanKnowledgeBase == null)
        {
            throw new NotFoundException();
        }

        return digitalHumanKnowledgeBase;
    }

    /// <summary>
    /// Update one DigitalHumanKnowledgeBase
    /// </summary>
    public async Task UpdateDigitalHumanKnowledgeBase(DigitalHumanKnowledgeBaseWhereUniqueInput uniqueId, DigitalHumanKnowledgeBaseUpdateInput updateDto)
    {
        var digitalHumanKnowledgeBase = updateDto.ToModel(uniqueId);

        if (updateDto.DigitalHuman != null)
        {
            digitalHumanKnowledgeBase.DigitalHuman = await _context
                .DigitalHumen.Where(digitalHuman => updateDto.DigitalHuman == digitalHuman.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(digitalHumanKnowledgeBase).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.DigitalHumanKnowledgeBases.Any(e => e.Id == digitalHumanKnowledgeBase.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

    /// <summary>
    /// Get a DigitalHuman record for DigitalHumanKnowledgeBase
    /// </summary>
    public async Task<DigitalHuman> GetDigitalHuman(DigitalHumanKnowledgeBaseWhereUniqueInput uniqueId)
    {
        var digitalHumanKnowledgeBase = await _context
              .DigitalHumanKnowledgeBases.Where(digitalHumanKnowledgeBase => digitalHumanKnowledgeBase.Id == uniqueId.Id)
      .Include(digitalHumanKnowledgeBase => digitalHumanKnowledgeBase.DigitalHuman)
      .FirstOrDefaultAsync();
        if (digitalHumanKnowledgeBase == null)
        {
            throw new NotFoundException();
        }
        return digitalHumanKnowledgeBase.DigitalHuman.ToDto();
    }

}
