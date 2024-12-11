using .APIs.Dtos;
using .APIs.Common;

namespace .APIs;

public interface IMarketingProductsService
{
    /// <summary>
    /// Create one MarketingProduct
    /// </summary>
    public Task<MarketingProduct> CreateMarketingProduct(MarketingProductCreateInput marketingproduct);
    /// <summary>
    /// Delete one MarketingProduct
    /// </summary>
    public Task DeleteMarketingProduct(MarketingProductWhereUniqueInput uniqueId);
    /// <summary>
    /// Find many MarketingProducts
    /// </summary>
    public Task<List<MarketingProduct>> MarketingProducts(MarketingProductFindManyArgs findManyArgs);
    /// <summary>
    /// Meta data about MarketingProduct records
    /// </summary>
    public Task<MetadataDto> MarketingProductsMeta(MarketingProductFindManyArgs findManyArgs);
    /// <summary>
    /// Get one MarketingProduct
    /// </summary>
    public Task<MarketingProduct> MarketingProduct(MarketingProductWhereUniqueInput uniqueId);
    /// <summary>
    /// Update one MarketingProduct
    /// </summary>
    public Task UpdateMarketingProduct(MarketingProductWhereUniqueInput uniqueId, MarketingProductUpdateInput updateDto);
    /// <summary>
    /// Get a DigitalHuman record for MarketingProduct
    /// </summary>
    public Task<DigitalHuman> GetDigitalHuman(MarketingProductWhereUniqueInput uniqueId);
}
