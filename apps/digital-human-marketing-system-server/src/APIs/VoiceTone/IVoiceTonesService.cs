using .APIs.Dtos;
using .APIs.Common;

namespace .APIs;

public interface IVoiceTonesService
{
    /// <summary>
    /// Create one VoiceTone
    /// </summary>
    public Task<VoiceTone> CreateVoiceTone(VoiceToneCreateInput voicetone);
    /// <summary>
    /// Delete one VoiceTone
    /// </summary>
    public Task DeleteVoiceTone(VoiceToneWhereUniqueInput uniqueId);
    /// <summary>
    /// Find many VoiceTones
    /// </summary>
    public Task<List<VoiceTone>> VoiceTones(VoiceToneFindManyArgs findManyArgs);
    /// <summary>
    /// Meta data about VoiceTone records
    /// </summary>
    public Task<MetadataDto> VoiceTonesMeta(VoiceToneFindManyArgs findManyArgs);
    /// <summary>
    /// Get one VoiceTone
    /// </summary>
    public Task<VoiceTone> VoiceTone(VoiceToneWhereUniqueInput uniqueId);
    /// <summary>
    /// Update one VoiceTone
    /// </summary>
    public Task UpdateVoiceTone(VoiceToneWhereUniqueInput uniqueId, VoiceToneUpdateInput updateDto);
}
