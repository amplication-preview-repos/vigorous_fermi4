using .APIs.Dtos;
using .APIs.Common;

namespace .APIs;

public interface IDigitalHumanStatsItemsService
{
    /// <summary>
    /// Create one DigitalHumanStats
    /// </summary>
    public Task<DigitalHumanStats> CreateDigitalHumanStats(DigitalHumanStatsCreateInput digitalhumanstats);
    /// <summary>
    /// Delete one DigitalHumanStats
    /// </summary>
    public Task DeleteDigitalHumanStats(DigitalHumanStatsWhereUniqueInput uniqueId);
    /// <summary>
    /// Find many DigitalHumanStatsItems
    /// </summary>
    public Task<List<DigitalHumanStats>> DigitalHumanStatsItems(DigitalHumanStatsFindManyArgs findManyArgs);
    /// <summary>
    /// Meta data about DigitalHumanStats records
    /// </summary>
    public Task<MetadataDto> DigitalHumanStatsItemsMeta(DigitalHumanStatsFindManyArgs findManyArgs);
    /// <summary>
    /// Get one DigitalHumanStats
    /// </summary>
    public Task<DigitalHumanStats> DigitalHumanStats(DigitalHumanStatsWhereUniqueInput uniqueId);
    /// <summary>
    /// Update one DigitalHumanStats
    /// </summary>
    public Task UpdateDigitalHumanStats(DigitalHumanStatsWhereUniqueInput uniqueId, DigitalHumanStatsUpdateInput updateDto);
    /// <summary>
    /// Get a DigitalHuman record for DigitalHumanStats
    /// </summary>
    public Task<DigitalHuman> GetDigitalHuman(DigitalHumanStatsWhereUniqueInput uniqueId);
}
