using .APIs;
using .Infrastructure;
using .APIs.Dtos;
using .Infrastructure.Models;
using .APIs.Errors;
using .APIs.Extensions;
using .APIs.Common;
using Microsoft.EntityFrameworkCore;

namespace .APIs;

public abstract class MarketingProductsServiceBase : IMarketingProductsService
{
    protected readonly DbContext _context;
    public MarketingProductsServiceBase(DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one MarketingProduct
    /// </summary>
    public async Task<MarketingProduct> CreateMarketingProduct(MarketingProductCreateInput createDto)
    {
        var marketingProduct = new MarketingProductDbModel
        {
            CreatedAt = createDto.CreatedAt,
            Description = createDto.Description,
            ProductImage = createDto.ProductImage,
            ProductName = createDto.ProductName,
            PurchaseLink = createDto.PurchaseLink,
            RecommendedWords = createDto.RecommendedWords,
            TargetAudience = createDto.TargetAudience,
            Title = createDto.Title,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            marketingProduct.Id = createDto.Id;
        }
        if (createDto.DigitalHuman != null)
        {
            marketingProduct.DigitalHuman = await _context
                .DigitalHumen.Where(digitalHuman => createDto.DigitalHuman.Id == digitalHuman.Id)
                .FirstOrDefaultAsync();
        }

        _context.MarketingProducts.Add(marketingProduct);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<MarketingProductDbModel>(marketingProduct.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one MarketingProduct
    /// </summary>
    public async Task DeleteMarketingProduct(MarketingProductWhereUniqueInput uniqueId)
    {
        var marketingProduct = await _context.MarketingProducts.FindAsync(uniqueId.Id);
        if (marketingProduct == null)
        {
            throw new NotFoundException();
        }

        _context.MarketingProducts.Remove(marketingProduct);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many MarketingProducts
    /// </summary>
    public async Task<List<MarketingProduct>> MarketingProducts(MarketingProductFindManyArgs findManyArgs)
    {
        var marketingProducts = await _context
              .MarketingProducts
      .Include(x => x.DigitalHuman)
      .ApplyWhere(findManyArgs.Where)
      .ApplySkip(findManyArgs.Skip)
      .ApplyTake(findManyArgs.Take)
      .ApplyOrderBy(findManyArgs.SortBy)
      .ToListAsync();
        return marketingProducts.ConvertAll(marketingProduct => marketingProduct.ToDto());
    }

    /// <summary>
    /// Meta data about MarketingProduct records
    /// </summary>
    public async Task<MetadataDto> MarketingProductsMeta(MarketingProductFindManyArgs findManyArgs)
    {

        var count = await _context
    .MarketingProducts
    .ApplyWhere(findManyArgs.Where)
    .CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one MarketingProduct
    /// </summary>
    public async Task<MarketingProduct> MarketingProduct(MarketingProductWhereUniqueInput uniqueId)
    {
        var marketingProducts = await this.MarketingProducts(
                  new MarketingProductFindManyArgs { Where = new MarketingProductWhereInput { Id = uniqueId.Id } }
      );
        var marketingProduct = marketingProducts.FirstOrDefault();
        if (marketingProduct == null)
        {
            throw new NotFoundException();
        }

        return marketingProduct;
    }

    /// <summary>
    /// Update one MarketingProduct
    /// </summary>
    public async Task UpdateMarketingProduct(MarketingProductWhereUniqueInput uniqueId, MarketingProductUpdateInput updateDto)
    {
        var marketingProduct = updateDto.ToModel(uniqueId);

        if (updateDto.DigitalHuman != null)
        {
            marketingProduct.DigitalHuman = await _context
                .DigitalHumen.Where(digitalHuman => updateDto.DigitalHuman == digitalHuman.Id)
                .FirstOrDefaultAsync();
        }

        _context.Entry(marketingProduct).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.MarketingProducts.Any(e => e.Id == marketingProduct.Id))
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
    /// Get a DigitalHuman record for MarketingProduct
    /// </summary>
    public async Task<DigitalHuman> GetDigitalHuman(MarketingProductWhereUniqueInput uniqueId)
    {
        var marketingProduct = await _context
              .MarketingProducts.Where(marketingProduct => marketingProduct.Id == uniqueId.Id)
      .Include(marketingProduct => marketingProduct.DigitalHuman)
      .FirstOrDefaultAsync();
        if (marketingProduct == null)
        {
            throw new NotFoundException();
        }
        return marketingProduct.DigitalHuman.ToDto();
    }

}
