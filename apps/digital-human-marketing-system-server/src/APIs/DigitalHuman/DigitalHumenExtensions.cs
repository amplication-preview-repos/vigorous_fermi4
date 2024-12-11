using .APIs.Dtos;
using .Infrastructure.Models;

namespace .APIs.Extensions;

public static class DigitalHumenExtensions
{
    public static DigitalHuman ToDto(this DigitalHumanDbModel model)
    {
        return new DigitalHuman
        {
            BusinessAccount = model.BusinessAccountId,
            CreatedAt = model.CreatedAt,
            Description = model.Description,
            DigitalHumanKnowledgeBases = model.DigitalHumanKnowledgeBases?.Select(x => x.Id).ToList(),
            DigitalHumanStatsItems = model.DigitalHumanStatsItems?.Select(x => x.Id).ToList(),
            Id = model.Id,
            MarketingProducts = model.MarketingProducts?.Select(x => x.Id).ToList(),
            Name = model.Name,
            PresentationVideos = model.PresentationVideos,
            StandbyVideos = model.StandbyVideos,
            UpdatedAt = model.UpdatedAt,

        };
    }

    public static DigitalHumanDbModel ToModel(this DigitalHumanUpdateInput updateDto, DigitalHumanWhereUniqueInput uniqueId)
    {
        var digitalHuman = new DigitalHumanDbModel
        {
            Id = uniqueId.Id,
            Description = updateDto.Description,
            Name = updateDto.Name,
            PresentationVideos = updateDto.PresentationVideos,
            StandbyVideos = updateDto.StandbyVideos
        };

        if (updateDto.BusinessAccount != null)
        {
            digitalHuman.BusinessAccountId = updateDto.BusinessAccount;
        }
        if (updateDto.CreatedAt != null)
        {
            digitalHuman.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            digitalHuman.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return digitalHuman;
    }

}
