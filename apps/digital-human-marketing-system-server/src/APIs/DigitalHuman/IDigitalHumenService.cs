using .APIs.Dtos;
using .APIs.Common;

namespace .APIs;

public interface IDigitalHumenService
{
    /// <summary>
    /// Create one DigitalHuman
    /// </summary>
    public Task<DigitalHuman> CreateDigitalHuman(DigitalHumanCreateInput digitalhuman);
    /// <summary>
    /// Delete one DigitalHuman
    /// </summary>
    public Task DeleteDigitalHuman(DigitalHumanWhereUniqueInput uniqueId);
    /// <summary>
    /// Find many DigitalHumen
    /// </summary>
    public Task<List<DigitalHuman>> DigitalHumen(DigitalHumanFindManyArgs findManyArgs);
    /// <summary>
    /// Meta data about DigitalHuman records
    /// </summary>
    public Task<MetadataDto> DigitalHumenMeta(DigitalHumanFindManyArgs findManyArgs);
    /// <summary>
    /// Get one DigitalHuman
    /// </summary>
    public Task<DigitalHuman> DigitalHuman(DigitalHumanWhereUniqueInput uniqueId);
    /// <summary>
    /// Update one DigitalHuman
    /// </summary>
    public Task UpdateDigitalHuman(DigitalHumanWhereUniqueInput uniqueId, DigitalHumanUpdateInput updateDto);
    /// <summary>
    /// Get a BusinessAccount record for DigitalHuman
    /// </summary>
    public Task<BusinessAccount> GetBusinessAccount(DigitalHumanWhereUniqueInput uniqueId);
    /// <summary>
    /// Connect multiple DigitalHumanKnowledgeBases records to DigitalHuman
    /// </summary>
    public Task ConnectDigitalHumanKnowledgeBases(DigitalHumanWhereUniqueInput uniqueId, DigitalHumanKnowledgeBaseWhereUniqueInput[] digitalHumanKnowledgeBasesId);
    /// <summary>
    /// Disconnect multiple DigitalHumanKnowledgeBases records from DigitalHuman
    /// </summary>
    public Task DisconnectDigitalHumanKnowledgeBases(DigitalHumanWhereUniqueInput uniqueId, DigitalHumanKnowledgeBaseWhereUniqueInput[] digitalHumanKnowledgeBasesId);
    /// <summary>
    /// Find multiple DigitalHumanKnowledgeBases records for DigitalHuman
    /// </summary>
    public Task<List<DigitalHumanKnowledgeBase>> FindDigitalHumanKnowledgeBases(DigitalHumanWhereUniqueInput uniqueId, DigitalHumanKnowledgeBaseFindManyArgs DigitalHumanKnowledgeBaseFindManyArgs);
    /// <summary>
    /// Update multiple DigitalHumanKnowledgeBases records for DigitalHuman
    /// </summary>
    public Task UpdateDigitalHumanKnowledgeBases(DigitalHumanWhereUniqueInput uniqueId, DigitalHumanKnowledgeBaseWhereUniqueInput[] digitalHumanKnowledgeBasesId);
    /// <summary>
    /// Connect multiple DigitalHumanStatsItems records to DigitalHuman
    /// </summary>
    public Task ConnectDigitalHumanStatsItems(DigitalHumanWhereUniqueInput uniqueId, DigitalHumanStatsWhereUniqueInput[] digitalHumanStatsId);
    /// <summary>
    /// Disconnect multiple DigitalHumanStatsItems records from DigitalHuman
    /// </summary>
    public Task DisconnectDigitalHumanStatsItems(DigitalHumanWhereUniqueInput uniqueId, DigitalHumanStatsWhereUniqueInput[] digitalHumanStatsId);
    /// <summary>
    /// Find multiple DigitalHumanStatsItems records for DigitalHuman
    /// </summary>
    public Task<List<DigitalHumanStats>> FindDigitalHumanStatsItems(DigitalHumanWhereUniqueInput uniqueId, DigitalHumanStatsFindManyArgs DigitalHumanStatsFindManyArgs);
    /// <summary>
    /// Update multiple DigitalHumanStatsItems records for DigitalHuman
    /// </summary>
    public Task UpdateDigitalHumanStatsItems(DigitalHumanWhereUniqueInput uniqueId, DigitalHumanStatsWhereUniqueInput[] digitalHumanStatsId);
    /// <summary>
    /// Connect multiple MarketingProducts records to DigitalHuman
    /// </summary>
    public Task ConnectMarketingProducts(DigitalHumanWhereUniqueInput uniqueId, MarketingProductWhereUniqueInput[] marketingProductsId);
    /// <summary>
    /// Disconnect multiple MarketingProducts records from DigitalHuman
    /// </summary>
    public Task DisconnectMarketingProducts(DigitalHumanWhereUniqueInput uniqueId, MarketingProductWhereUniqueInput[] marketingProductsId);
    /// <summary>
    /// Find multiple MarketingProducts records for DigitalHuman
    /// </summary>
    public Task<List<MarketingProduct>> FindMarketingProducts(DigitalHumanWhereUniqueInput uniqueId, MarketingProductFindManyArgs MarketingProductFindManyArgs);
    /// <summary>
    /// Update multiple MarketingProducts records for DigitalHuman
    /// </summary>
    public Task UpdateMarketingProducts(DigitalHumanWhereUniqueInput uniqueId, MarketingProductWhereUniqueInput[] marketingProductsId);
}
