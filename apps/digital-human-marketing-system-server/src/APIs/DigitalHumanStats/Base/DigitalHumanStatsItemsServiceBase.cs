using .APIs;
using .Infrastructure;
using .APIs.Dtos;
using .Infrastructure.Models;
using .APIs.Errors;
using .APIs.Extensions;
using .APIs.Common;
using Microsoft.EntityFrameworkCore;

namespace .APIs;

public abstract class DigitalHumanStatsItemsServiceBase : IDigitalHumanStatsItemsService
{
    protected readonly DbContext _context;
    public DigitalHumanStatsItemsServiceBase(DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one DigitalHumanStats
    /// </summary>
    public async Task<DigitalHumanStats> CreateDigitalHumanStats(DigitalHumanStatsCreateInput createDto)
    {
        var digitalHumanStats = new DigitalHumanStatsDbModel
        {
            ConversationCount = createDto.ConversationCount,
            ConversationDuration = createDto.ConversationDuration,
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt,
            ViewCount = createDto.ViewCount
        };

        if (createDto.Id != null)
        {
            digitalHumanStats.Id = createDto.Id;
        }
        if (createDto.DigitalHuman != null)
        {
            digitalHumanStats.DigitalHuman = await _context
                .DigitalHumen.Where(digitalHuman => createDto.DigitalHuman.Id == digitalHuman.Id)
                .FirstOrDefaultAsync();
        }

        _context.DigitalHumanStatsItems.Add(digitalHumanStats);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<DigitalHumanStatsDbModel>(digitalHumanStats.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one DigitalHumanStats
    /// </summary>
    public async Task DeleteDigitalHumanStats(DigitalHumanStatsWhereUniqueInput uniqueId)
    {
        var digitalHumanStats = await _context.DigitalHumanStatsItems.FindAsync(uniqueId.Id);
        if (digitalHumanStats == null)
        {
            throw new NotFoundException();
        }

        _context.DigitalHumanStatsItems.Remove(digitalHumanStats);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many DigitalHumanStatsItems
    /// </summary>
    public async Task<List<DigitalHumanStats>> DigitalHumanStatsItems(DigitalHumanStatsFindManyArgs findManyArgs)
    {
        var digitalHumanStatsItems = await _context
              .DigitalHumanStatsItems
      .Include(x => x.DigitalHuman)
      .ApplyWhere(findManyArgs.Where)
      .ApplySkip(findManyArgs.Skip)
      .ApplyTake(findManyArgs.Take)
      .ApplyOrderBy(findManyArgs.SortBy)
      .ToListAsync();
        return digitalHumanStatsItems.ConvertAll(digitalHumanStats => digitalHumanStats.ToDto());
    }

    /// <summary>
    /// Meta data about DigitalHumanStats records
    /// </summary>
    public async Task<MetadataDto> DigitalHumanStatsItemsMeta(DigitalHumanStatsFindManyArgs findManyArgs)
    {

        var count = await _context
    .DigitalHumanStatsItems
    .ApplyWhere(findManyArgs.Where)
    .CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one DigitalHumanStats
    /// </summary>
    public async Task<DigitalHumanStats> DigitalHumanStats(DigitalHumanStatsWhereUniqueInput uniqueId)
    {
        var digitalHumanStatsItems = await this.DigitalHumanStatsItems(
                  new DigitalHumanStatsFindManyArgs { Where = new DigitalHumanStatsWhereInput { Id = uniqueId.Id } }
      );
        var digitalHumanStats = digitalHumanStatsItems.FirstOrDefault();
        if (digitalHumanStats == null)
        {
            throw new NotFoundException();
        }

        return digitalHumanStats;
    }

    /// <summary>
    /// Update one DigitalHumanStats
    /// </summary>
    public async Task UpdateDigitalHumanStats(DigitalHumanStatsWhereUniqueInput uniqueId, DigitalHumanStatsUpdateInput updateDto)
    {
        var digitalHumanStats = updateDto.ToModel(uniqueId);

        if (updateDto.DigitalHuman != null)
        {
            digitalHumanStats.DigitalHuman = await _context
                .DigitalHumen.Where(digitalHuman => updateDto.DigitalHuman == digitalHuman.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(digitalHumanStats).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.DigitalHumanStatsItems.Any(e => e.Id == digitalHumanStats.Id))
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
    /// Get a DigitalHuman record for DigitalHumanStats
    /// </summary>
    public async Task<DigitalHuman> GetDigitalHuman(DigitalHumanStatsWhereUniqueInput uniqueId)
    {
        var digitalHumanStats = await _context
              .DigitalHumanStatsItems.Where(digitalHumanStats => digitalHumanStats.Id == uniqueId.Id)
      .Include(digitalHumanStats => digitalHumanStats.DigitalHuman)
      .FirstOrDefaultAsync();
        if (digitalHumanStats == null)
        {
            throw new NotFoundException();
        }
        return digitalHumanStats.DigitalHuman.ToDto();
    }

}
