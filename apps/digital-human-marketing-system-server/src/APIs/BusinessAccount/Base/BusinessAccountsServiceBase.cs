using .APIs;
using .Infrastructure;
using .APIs.Dtos;
using .Infrastructure.Models;
using .APIs.Errors;
using .APIs.Extensions;
using .APIs.Common;
using Microsoft.EntityFrameworkCore;

namespace .APIs;

public abstract class BusinessAccountsServiceBase : IBusinessAccountsService
{
    protected readonly DbContext _context;
    public BusinessAccountsServiceBase(DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one BusinessAccount
    /// </summary>
    public async Task<BusinessAccount> CreateBusinessAccount(BusinessAccountCreateInput createDto)
    {
        var businessAccount = new BusinessAccountDbModel
        {
            BusinessName = createDto.BusinessName,
            ContactEmail = createDto.ContactEmail,
            ContactPhone = createDto.ContactPhone,
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            businessAccount.Id = createDto.Id;
        }
        if (createDto.DigitalHumen != null)
        {
            businessAccount.DigitalHumen = await _context
                .DigitalHumen.Where(digitalHuman => createDto.DigitalHumen.Select(t => t.Id).Contains(digitalHuman.Id))
                .ToListAsync();
        }

        _context.BusinessAccounts.Add(businessAccount);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<BusinessAccountDbModel>(businessAccount.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one BusinessAccount
    /// </summary>
    public async Task DeleteBusinessAccount(BusinessAccountWhereUniqueInput uniqueId)
    {
        var businessAccount = await _context.BusinessAccounts.FindAsync(uniqueId.Id);
        if (businessAccount == null)
        {
            throw new NotFoundException();
        }

        _context.BusinessAccounts.Remove(businessAccount);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many BusinessAccounts
    /// </summary>
    public async Task<List<BusinessAccount>> BusinessAccounts(BusinessAccountFindManyArgs findManyArgs)
    {
        var businessAccounts = await _context
              .BusinessAccounts
      .Include(x => x.DigitalHumen)
      .ApplyWhere(findManyArgs.Where)
      .ApplySkip(findManyArgs.Skip)
      .ApplyTake(findManyArgs.Take)
      .ApplyOrderBy(findManyArgs.SortBy)
      .ToListAsync();
        return businessAccounts.ConvertAll(businessAccount => businessAccount.ToDto());
    }

    /// <summary>
    /// Meta data about BusinessAccount records
    /// </summary>
    public async Task<MetadataDto> BusinessAccountsMeta(BusinessAccountFindManyArgs findManyArgs)
    {

        var count = await _context
    .BusinessAccounts
    .ApplyWhere(findManyArgs.Where)
    .CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one BusinessAccount
    /// </summary>
    public async Task<BusinessAccount> BusinessAccount(BusinessAccountWhereUniqueInput uniqueId)
    {
        var businessAccounts = await this.BusinessAccounts(
                  new BusinessAccountFindManyArgs { Where = new BusinessAccountWhereInput { Id = uniqueId.Id } }
      );
        var businessAccount = businessAccounts.FirstOrDefault();
        if (businessAccount == null)
        {
            throw new NotFoundException();
        }

        return businessAccount;
    }

    /// <summary>
    /// Update one BusinessAccount
    /// </summary>
    public async Task UpdateBusinessAccount(BusinessAccountWhereUniqueInput uniqueId, BusinessAccountUpdateInput updateDto)
    {
        var businessAccount = updateDto.ToModel(uniqueId);

        if (updateDto.DigitalHumen != null)
        {
            businessAccount.DigitalHumen = await _context
                .DigitalHumen.Where(digitalHuman => updateDto.DigitalHumen.Select(t => t).Contains(digitalHuman.Id))
                .ToListAsync();
        }

        _context.Entry(businessAccount).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.BusinessAccounts.Any(e => e.Id == businessAccount.Id))
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
    /// Connect multiple DigitalHumen records to BusinessAccount
    /// </summary>
    public async Task ConnectDigitalHumen(BusinessAccountWhereUniqueInput uniqueId, DigitalHumanWhereUniqueInput[] childrenIds)
    {
        var parent = await _context
              .BusinessAccounts.Include(x => x.DigitalHumen)
      .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
          .DigitalHumen.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
          .ToListAsync();
        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        var childrenToConnect = children.Except(parent.DigitalHumen);

        foreach (var child in childrenToConnect)
        {
            parent.DigitalHumen.Add(child);
        }

        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Disconnect multiple DigitalHumen records from BusinessAccount
    /// </summary>
    public async Task DisconnectDigitalHumen(BusinessAccountWhereUniqueInput uniqueId, DigitalHumanWhereUniqueInput[] childrenIds)
    {
        var parent = await _context
                                .BusinessAccounts.Include(x => x.DigitalHumen)
                        .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (parent == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
          .DigitalHumen.Where(t => childrenIds.Select(x => x.Id).Contains(t.Id))
          .ToListAsync();

        foreach (var child in children)
        {
            parent.DigitalHumen?.Remove(child);
        }
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find multiple DigitalHumen records for BusinessAccount
    /// </summary>
    public async Task<List<DigitalHuman>> FindDigitalHumen(BusinessAccountWhereUniqueInput uniqueId, DigitalHumanFindManyArgs businessAccountFindManyArgs)
    {
        var digitalHumen = await _context
              .DigitalHumen
      .Where(m => m.BusinessAccountId == uniqueId.Id)
      .ApplyWhere(businessAccountFindManyArgs.Where)
      .ApplySkip(businessAccountFindManyArgs.Skip)
      .ApplyTake(businessAccountFindManyArgs.Take)
      .ApplyOrderBy(businessAccountFindManyArgs.SortBy)
      .ToListAsync();

        return digitalHumen.Select(x => x.ToDto()).ToList();
    }

    /// <summary>
    /// Update multiple DigitalHumen records for BusinessAccount
    /// </summary>
    public async Task UpdateDigitalHumen(BusinessAccountWhereUniqueInput uniqueId, DigitalHumanWhereUniqueInput[] childrenIds)
    {
        var businessAccount = await _context
                .BusinessAccounts.Include(t => t.DigitalHumen)
        .FirstOrDefaultAsync(x => x.Id == uniqueId.Id);
        if (businessAccount == null)
        {
            throw new NotFoundException();
        }

        var children = await _context
          .DigitalHumen.Where(a => childrenIds.Select(x => x.Id).Contains(a.Id))
          .ToListAsync();

        if (children.Count == 0)
        {
            throw new NotFoundException();
        }

        businessAccount.DigitalHumen = children;
        await _context.SaveChangesAsync();
    }

}
