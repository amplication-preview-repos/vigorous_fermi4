using .APIs;
using .Infrastructure;
using .APIs.Dtos;
using .Infrastructure.Models;
using .APIs.Errors;
using .APIs.Extensions;
using .APIs.Common;
using Microsoft.EntityFrameworkCore;

namespace .APIs;

public abstract class DigitalHumenServiceBase : IDigitalHumenService
{
    protected readonly DbContext _context;
    public DigitalHumenServiceBase(DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one DigitalHuman
    /// </summary>
    public async Task<DigitalHuman> CreateDigitalHuman(DigitalHumanCreateInput createDto)
    {
        var digitalHuman = new DigitalHumanDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Description = createDto.Description,
            Name = createDto.Name,
            PresentationVideos = createDto.PresentationVideos,
            StandbyVideos = createDto.StandbyVideos,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            digitalHuman.Id = createDto.Id;
        }
        if (createDto.BusinessAccount != null)
        {
            digitalHuman.BusinessAccount = await _context
                .BusinessAccounts.Where(businessAccount => createDto.BusinessAccount.Id == businessAccount.Id)
                .FirstOrDefaultAsync();
        }

        if (createDto.DigitalHumanKnowledgeBases != null)
        {
            digitalHuman.DigitalHumanKnowledgeBases = await _context
                .DigitalHumanKnowledgeBases.Where(digitalHumanKnowledgeBase => createDto.DigitalHumanKnowledgeBases.Select(t => t.Id).Contains(digitalHumanKnowledgeBase.Id))
                .ToListAsync();
        }

        if (createDto.DigitalHumanStatsItems != null)
        {
            digitalHuman.DigitalHumanStatsItems = await _context
                .DigitalHumanStatsItems.Where(digitalHumanStats => createDto.DigitalHumanStatsItems.Select(t => t.Id).Contains(digitalHumanStats.Id))
                .ToListAsync();
        }

        if (createDto.MarketingProducts != null)
        {
            digitalHuman.MarketingProducts = await _context
                .MarketingProducts.Where(marketingProduct => createDto.MarketingProducts.Select(t => t.Id).Contains(marketingProduct.Id))
                .ToListAsync();
        }

        _context.DigitalHumen.Add(digitalHuman);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<DigitalHumanDbModel>(digitalHuman.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one DigitalHuman
    /// </summary>
    public async Task DeleteDigitalHuman(DigitalHumanWhereUniqueInput uniqueId)
    {
        var digitalHuman = await _context.DigitalHumen.FindAsync(uniqueId.Id);
        if (digitalHuman == null)
        {
            throw new NotFoundException();
        }

        _context.DigitalHumen.Remove(digitalHuman);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many DigitalHumen
    /// </summary>
    public async Task<List<DigitalHuman>> DigitalHumen(DigitalHumanFindManyArgs findManyArgs)
    {
        var digitalHumen = await _context
              .DigitalHumen
      .Include(x => x.BusinessAccount).Include(x => x.DigitalHumanStatsItems).Include(x => x.DigitalHumanKnowledgeBases).Include(x => x.MarketingProducts)
      .ApplyWhere(findManyArgs.Where)
      .ApplySkip(findManyArgs.Skip)
      .ApplyTake(findManyArgs.Take)
      .ApplyOrderBy(findManyArgs.SortBy)
      .ToListAsync();
        return digitalHumen.ConvertAll(digitalHuman => digitalHuman.ToDto());
    }

    /// <summary>
    /// Meta data about DigitalHuman records
    /// </summary>
    public async Task<MetadataDto> DigitalHumenMeta(DigitalHumanFindManyArgs findManyArgs)
    {

        var count = await _context
    .DigitalHumen
    .ApplyWhere(findManyArgs.Where)
    .CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one DigitalHuman
    /// </summary>
    public async Task<DigitalHuman> DigitalHuman(DigitalHumanWhereUniqueInput uniqueId)
    {
        var digitalHumen = await this.DigitalHumen(
                  new DigitalHumanFindManyArgs { Where = new DigitalHumanWhereInput { Id = uniqueId.Id } }
      );
        var digitalHuman = digitalHumen.FirstOrDefault();
        if (digitalHuman == null)
        {
            throw new NotFoundException();
        }

        return digitalHuman;
    }

    /// <summary>
    /// Update one DigitalHuman
    /// </summary>
    public async Task UpdateDigitalHuman(DigitalHumanWhereUniqueInput uniqueId, DigitalHumanUpdateInput updateDto)
    {
        var digitalHuman = updateDto.ToModel(uniqueId);

        if (updateDto.BusinessAccount != null)
        {
            digitalHuman.BusinessAccount = await _context
                .BusinessAccounts.Where(businessAccount => updateDto.BusinessAccount == businessAccount.Id)
                .FirstOrDefaultAsync();
        }

        if (updateDto.DigitalHumanKnowledgeBases != null)
        {
            digitalHuman.DigitalHumanKnowledgeBases = await _context
                .DigitalHumanKnowledgeBases.Where(digitalHumanKnowledgeBase => updateDto.DigitalHumanKnowledgeBases.Select(t => t).Contains(digitalHumanKnowledgeBase.Id))
                .ToListAsync();
        }

        if (updateDto.DigitalHumanStatsItems != null)
        {
            digitalHuman.DigitalHumanStatsItems = await _context
                .DigitalHumanStatsItems.Where(digitalHumanStats => updateDto.DigitalHumanStatsItems.Select(t => t).Contains(digitalHumanStats.Id))
                .ToListAsync();
        }

        if (updateDto.MarketingProducts != null)
        {
            digitalHuman.MarketingProducts = await _context
                .MarketingProducts.Where(marketingProduct => updateDto.MarketingProducts.Select(t => t).Contains(marketingProduct.Id))
                .ToListAsync();
        }

        _context.Entry(digitalHuman).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.DigitalHumen.Any(e => e.Id == digitalHuman.Id))
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
    /// Get a BusinessAccount record for DigitalHuman
    /// </summary>
    public async Task<BusinessAccount> GetBusinessAccount(DigitalHumanWhereUniqueInput uniqueId)
    {
        var digitalHuman = await _context
              .DigitalHumen.Where(digitalHuman => digitalHuman.Id == uniqueId.Id)
      .Include(digitalHuman => digitalHuman.BusinessAccount)
      .FirstOrDefaultAsync();
        if (digitalHuman == null)
        {
            throw new NotFoundException();
        }
        return digitalHuman.BusinessAccount.ToDto();
    }

    /// <summary>
    /// Connect multiple DigitalHumanKnowledgeBases records to DigitalHuman
    /// </summary>
    public async Task ConnectDigitalHumanKnowledgeBases(DigitalHumanWhereUniqueInput uniqueId, DigitalHumanKnowledgeBaseWhereUniqueInput[] childrenIds)
    {
        var parent = await _context
              .DigitalHumen.Include(x => x.DigitalHumanKnowledgeBases)
      .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
          .DigitalHumanKnowledgeBases.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
          .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.DigitalHumanKnowledgeBases);

        foreach (var child in childrenToConnect)
        {
            parent.DigitalHumanKnowledgeBases.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple DigitalHumanKnowledgeBases records from DigitalHuman
    /// </summary>
    public async Task DisconnectDigitalHumanKnowledgeBases(DigitalHumanWhereUniqueInput uniqueId, DigitalHumanKnowledgeBaseWhereUniqueInput[] childrenIds)
    {
        var parent = await _context
                                .DigitalHumen.Include(x => x.DigitalHumanKnowledgeBases)
                        .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
          .DigitalHumanKnowledgeBases.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
          .ToListAsync();

        foreach (var child in children)
        {
            parent.DigitalHumanKnowledgeBases?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple DigitalHumanKnowledgeBases records for DigitalHuman
    /// </summary>
    public async Task<List<DigitalHumanKnowledgeBase>> FindDigitalHumanKnowledgeBases(DigitalHumanWhereUniqueInput uniqueId, DigitalHumanKnowledgeBaseFindManyArgs digitalHumanFindManyArgs)
    {
        var digitalHumanKnowledgeBases = await _context
              .DigitalHumanKnowledgeBases
      .Where(m => m.DigitalHumanId == uniqueId.Id)
      .ApplyWhere(digitalHumanFindManyArgs.Where)
      .ApplySkip(digitalHumanFindManyArgs.Skip)
      .ApplyTake(digitalHumanFindManyArgs.Take)
      .ApplyOrderBy(digitalHumanFindManyArgs.SortBy)
      .ToListAsync();

        return digitalHumanKnowledgeBases.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple DigitalHumanKnowledgeBases records for DigitalHuman
    /// </summary>
    public async Task UpdateDigitalHumanKnowledgeBases(DigitalHumanWhereUniqueInput uniqueId, DigitalHumanKnowledgeBaseWhereUniqueInput[] childrenIds)
    {
        var digitalHuman = await _context
                .DigitalHumen.Include(t => t.DigitalHumanKnowledgeBases)
        .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (digitalHuman == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
          .DigitalHumanKnowledgeBases.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
          .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        digitalHuman.DigitalHumanKnowledgeBases = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple DigitalHumanStatsItems records to DigitalHuman
    /// </summary>
    public async Task ConnectDigitalHumanStatsItems(DigitalHumanWhereUniqueInput uniqueId, DigitalHumanStatsWhereUniqueInput[] childrenIds)
    {
        var parent = await _context
              .DigitalHumen.Include(x => x.DigitalHumanStatsItems)
      .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
          .DigitalHumanStatsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
          .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.DigitalHumanStatsItems);

        foreach (var child in childrenToConnect)
        {
            parent.DigitalHumanStatsItems.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple DigitalHumanStatsItems records from DigitalHuman
    /// </summary>
    public async Task DisconnectDigitalHumanStatsItems(DigitalHumanWhereUniqueInput uniqueId, DigitalHumanStatsWhereUniqueInput[] childrenIds)
    {
        var parent = await _context
                                .DigitalHumen.Include(x => x.DigitalHumanStatsItems)
                        .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
          .DigitalHumanStatsItems.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
          .ToListAsync();

        foreach (var child in children)
        {
            parent.DigitalHumanStatsItems?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple DigitalHumanStatsItems records for DigitalHuman
    /// </summary>
    public async Task<List<DigitalHumanStats>> FindDigitalHumanStatsItems(DigitalHumanWhereUniqueInput uniqueId, DigitalHumanStatsFindManyArgs digitalHumanFindManyArgs)
    {
        var digitalHumanStatsItems = await _context
              .DigitalHumanStatsItems
      .Where(m => m.DigitalHumanId == uniqueId.Id)
      .ApplyWhere(digitalHumanFindManyArgs.Where)
      .ApplySkip(digitalHumanFindManyArgs.Skip)
      .ApplyTake(digitalHumanFindManyArgs.Take)
      .ApplyOrderBy(digitalHumanFindManyArgs.SortBy)
      .ToListAsync();

        return digitalHumanStatsItems.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple DigitalHumanStatsItems records for DigitalHuman
    /// </summary>
    public async Task UpdateDigitalHumanStatsItems(DigitalHumanWhereUniqueInput uniqueId, DigitalHumanStatsWhereUniqueInput[] childrenIds)
    {
        var digitalHuman = await _context
                .DigitalHumen.Include(t => t.DigitalHumanStatsItems)
        .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (digitalHuman == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
          .DigitalHumanStatsItems.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
          .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        digitalHuman.DigitalHumanStatsItems = children;
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Connect multiple MarketingProducts records to DigitalHuman
    /// </summary>
    public async Task ConnectMarketingProducts(DigitalHumanWhereUniqueInput uniqueId, MarketingProductWhereUniqueInput[] childrenIds)
    {
        var parent = await _context
              .DigitalHumen.Include(x => x.MarketingProducts)
      .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
          .MarketingProducts.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
          .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.MarketingProducts);

        foreach (var child in childrenToConnect)
        {
            parent.MarketingProducts.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple MarketingProducts records from DigitalHuman
    /// </summary>
    public async Task DisconnectMarketingProducts(DigitalHumanWhereUniqueInput uniqueId, MarketingProductWhereUniqueInput[] childrenIds)
    {
        var parent = await _context
                                .DigitalHumen.Include(x => x.MarketingProducts)
                        .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
          .MarketingProducts.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
          .ToListAsync();

        foreach (var child in children)
        {
            parent.MarketingProducts?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple MarketingProducts records for DigitalHuman
    /// </summary>
    public async Task<List<MarketingProduct>> FindMarketingProducts(DigitalHumanWhereUniqueInput uniqueId, MarketingProductFindManyArgs digitalHumanFindManyArgs)
    {
        var marketingProducts = await _context
              .MarketingProducts
      .Where(m => m.DigitalHumanId == uniqueId.Id)
      .ApplyWhere(digitalHumanFindManyArgs.Where)
      .ApplySkip(digitalHumanFindManyArgs.Skip)
      .ApplyTake(digitalHumanFindManyArgs.Take)
      .ApplyOrderBy(digitalHumanFindManyArgs.SortBy)
      .ToListAsync();

        return marketingProducts.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple MarketingProducts records for DigitalHuman
    /// </summary>
    public async Task UpdateMarketingProducts(DigitalHumanWhereUniqueInput uniqueId, MarketingProductWhereUniqueInput[] childrenIds)
    {
        var digitalHuman = await _context
                .DigitalHumen.Include(t => t.MarketingProducts)
        .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (digitalHuman == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
          .MarketingProducts.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
          .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        digitalHuman.MarketingProducts = children;
        await _context.SaveChangesAsync();
    }

}
