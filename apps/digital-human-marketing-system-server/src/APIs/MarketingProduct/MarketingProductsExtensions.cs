using .APIs.Dtos;
using .Infrastructure.Models;

namespace .APIs.Extensions;

public static class MarketingProductsExtensions
{
    public static MarketingProduct ToDto(this MarketingProductDbModel model)
    {
        return new MarketingProduct
        {
            CreatedAt = model.CreatedAt,
            Description = model.Description,
            DigitalHuman = model.DigitalHumanId,
            Id = model.Id,
            ProductImage = model.ProductImage,
            ProductName = model.ProductName,
            PurchaseLink = model.PurchaseLink,
            RecommendedWords = model.RecommendedWords,
            TargetAudience = model.TargetAudience,
            Title = model.Title,
            UpdatedAt = model.UpdatedAt,

        };
    }

    public static MarketingProductDbModel ToModel(this MarketingProductUpdateInput updateDto, MarketingProductWhereUniqueInput uniqueId)
    {
        var marketingProduct = new MarketingProductDbModel
        {
            Id = uniqueId.Id,
            Description = updateDto.Description,
            ProductImage = updateDto.ProductImage,
            ProductName = updateDto.ProductName,
            PurchaseLink = updateDto.PurchaseLink,
            RecommendedWords = updateDto.RecommendedWords,
            TargetAudience = updateDto.TargetAudience,
            Title = updateDto.Title
        };

        if (updateDto.CreatedAt != null)
        {
            marketingProduct.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.DigitalHuman != null)
        {
            marketingProduct.DigitalHumanId = updateDto.DigitalHuman;
        }
        if (updateDto.UpdatedAt != null)
        {
            marketingProduct.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return marketingProduct;
    }

}
