using .APIs.Dtos;
using .APIs.Common;

namespace .APIs;

public interface IBusinessAccountsService
{
    /// <summary>
    /// Create one BusinessAccount
    /// </summary>
    public Task<BusinessAccount> CreateBusinessAccount(BusinessAccountCreateInput businessaccount);
    /// <summary>
    /// Delete one BusinessAccount
    /// </summary>
    public Task DeleteBusinessAccount(BusinessAccountWhereUniqueInput uniqueId);
    /// <summary>
    /// Find many BusinessAccounts
    /// </summary>
    public Task<List<BusinessAccount>> BusinessAccounts(BusinessAccountFindManyArgs findManyArgs);
    /// <summary>
    /// Meta data about BusinessAccount records
    /// </summary>
    public Task<MetadataDto> BusinessAccountsMeta(BusinessAccountFindManyArgs findManyArgs);
    /// <summary>
    /// Get one BusinessAccount
    /// </summary>
    public Task<BusinessAccount> BusinessAccount(BusinessAccountWhereUniqueInput uniqueId);
    /// <summary>
    /// Update one BusinessAccount
    /// </summary>
    public Task UpdateBusinessAccount(BusinessAccountWhereUniqueInput uniqueId, BusinessAccountUpdateInput updateDto);
    /// <summary>
    /// Connect multiple DigitalHumen records to BusinessAccount
    /// </summary>
    public Task ConnectDigitalHumen(BusinessAccountWhereUniqueInput uniqueId, DigitalHumanWhereUniqueInput[] digitalHumenId);
    /// <summary>
    /// Disconnect multiple DigitalHumen records from BusinessAccount
    /// </summary>
    public Task DisconnectDigitalHumen(BusinessAccountWhereUniqueInput uniqueId, DigitalHumanWhereUniqueInput[] digitalHumenId);
    /// <summary>
    /// Find multiple DigitalHumen records for BusinessAccount
    /// </summary>
    public Task<List<DigitalHuman>> FindDigitalHumen(BusinessAccountWhereUniqueInput uniqueId, DigitalHumanFindManyArgs DigitalHumanFindManyArgs);
    /// <summary>
    /// Update multiple DigitalHumen records for BusinessAccount
    /// </summary>
    public Task UpdateDigitalHumen(BusinessAccountWhereUniqueInput uniqueId, DigitalHumanWhereUniqueInput[] digitalHumenId);
}
