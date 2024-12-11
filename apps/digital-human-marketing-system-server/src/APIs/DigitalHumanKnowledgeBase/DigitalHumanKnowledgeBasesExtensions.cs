using .APIs.Dtos;
using .Infrastructure.Models;

namespace .APIs.Extensions;

public static class DigitalHumanKnowledgeBasesExtensions
{
    public static DigitalHumanKnowledgeBase ToDto(this DigitalHumanKnowledgeBaseDbModel model)
    {
        return new DigitalHumanKnowledgeBase
        {
            CreatedAt = model.CreatedAt,
            DigitalHuman = model.DigitalHumanId,
            DocumentLink = model.DocumentLink,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,

        };
    }

    public static DigitalHumanKnowledgeBaseDbModel ToModel(this DigitalHumanKnowledgeBaseUpdateInput updateDto, DigitalHumanKnowledgeBaseWhereUniqueInput uniqueId)
    {
        var digitalHumanKnowledgeBase = new DigitalHumanKnowledgeBaseDbModel
        {
            Id = uniqueId.Id,
            DocumentLink = updateDto.DocumentLink
        };

        if (updateDto.CreatedAt != null)
        {
            digitalHumanKnowledgeBase.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.DigitalHuman != null)
        {
            digitalHumanKnowledgeBase.DigitalHumanId = updateDto.DigitalHuman;
        }
        if (updateDto.UpdatedAt != null)
        {
            digitalHumanKnowledgeBase.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return digitalHumanKnowledgeBase;
    }

}
