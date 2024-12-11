using .APIs.Dtos;
using .Infrastructure.Models;

namespace .APIs.Extensions;

public static class VoiceTonesExtensions
{
    public static VoiceTone ToDto(this VoiceToneDbModel model)
    {
        return new VoiceTone
        {
            AudioFile = model.AudioFile,
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            Name = model.Name,
            TextSummary = model.TextSummary,
            UpdatedAt = model.UpdatedAt,

        };
    }

    public static VoiceToneDbModel ToModel(this VoiceToneUpdateInput updateDto, VoiceToneWhereUniqueInput uniqueId)
    {
        var voiceTone = new VoiceToneDbModel
        {
            Id = uniqueId.Id,
            AudioFile = updateDto.AudioFile,
            Name = updateDto.Name,
            TextSummary = updateDto.TextSummary
        };

        if (updateDto.CreatedAt != null)
        {
            voiceTone.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            voiceTone.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return voiceTone;
    }

}
