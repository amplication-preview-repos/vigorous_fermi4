using .APIs.Dtos;
using .Infrastructure.Models;

namespace .APIs.Extensions;

public static class DigitalHumanStatsItemsExtensions
{
    public static DigitalHumanStats ToDto(this DigitalHumanStatsDbModel model)
    {
        return new DigitalHumanStats
        {
            ConversationCount = model.ConversationCount,
            ConversationDuration = model.ConversationDuration,
            CreatedAt = model.CreatedAt,
            DigitalHuman = model.DigitalHumanId,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
            ViewCount = model.ViewCount,

        };
    }

    public static DigitalHumanStatsDbModel ToModel(this DigitalHumanStatsUpdateInput updateDto, DigitalHumanStatsWhereUniqueInput uniqueId)
    {
        var digitalHumanStats = new DigitalHumanStatsDbModel
        {
            Id = uniqueId.Id,
            ConversationCount = updateDto.ConversationCount,
            ConversationDuration = updateDto.ConversationDuration,
            ViewCount = updateDto.ViewCount
        };

        if (updateDto.CreatedAt != null)
        {
            digitalHumanStats.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.DigitalHuman != null)
        {
            digitalHumanStats.DigitalHumanId = updateDto.DigitalHuman;
        }
        if (updateDto.UpdatedAt != null)
        {
            digitalHumanStats.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return digitalHumanStats;
    }

}
