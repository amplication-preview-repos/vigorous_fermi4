using .APIs;
using .Infrastructure;
using .APIs.Dtos;
using .Infrastructure.Models;
using .APIs.Errors;
using .APIs.Extensions;
using .APIs.Common;
using Microsoft.EntityFrameworkCore;

namespace .APIs;

public abstract class VoiceTonesServiceBase : IVoiceTonesService
{
    protected readonly DbContext _context;
    public VoiceTonesServiceBase(DbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one VoiceTone
    /// </summary>
    public async Task<VoiceTone> CreateVoiceTone(VoiceToneCreateInput createDto)
    {
        var voiceTone = new VoiceToneDbModel
        {
            AudioFile = createDto.AudioFile,
            CreatedAt = createDto.CreatedAt,
            Name = createDto.Name,
            TextSummary = createDto.TextSummary,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            voiceTone.Id = createDto.Id;
        }


        _context.VoiceTones.Add(voiceTone);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<VoiceToneDbModel>(voiceTone.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one VoiceTone
    /// </summary>
    public async Task DeleteVoiceTone(VoiceToneWhereUniqueInput uniqueId)
    {
        var voiceTone = await _context.VoiceTones.FindAsync(uniqueId.Id);
        if (voiceTone == null)
        {
            throw new NotFoundException();
        }

        _context.VoiceTones.Remove(voiceTone);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many VoiceTones
    /// </summary>
    public async Task<List<VoiceTone>> VoiceTones(VoiceToneFindManyArgs findManyArgs)
    {
        var voiceTones = await _context
              .VoiceTones

      .ApplyWhere(findManyArgs.Where)
      .ApplySkip(findManyArgs.Skip)
      .ApplyTake(findManyArgs.Take)
      .ApplyOrderBy(findManyArgs.SortBy)
      .ToListAsync();
        return voiceTones.ConvertAll(voiceTone => voiceTone.ToDto());
    }

    /// <summary>
    /// Meta data about VoiceTone records
    /// </summary>
    public async Task<MetadataDto> VoiceTonesMeta(VoiceToneFindManyArgs findManyArgs)
    {

        var count = await _context
    .VoiceTones
    .ApplyWhere(findManyArgs.Where)
    .CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one VoiceTone
    /// </summary>
    public async Task<VoiceTone> VoiceTone(VoiceToneWhereUniqueInput uniqueId)
    {
        var voiceTones = await this.VoiceTones(
                  new VoiceToneFindManyArgs { Where = new VoiceToneWhereInput { Id = uniqueId.Id } }
      );
        var voiceTone = voiceTones.FirstOrDefault();
        if (voiceTone == null)
        {
            throw new NotFoundException();
        }

        return voiceTone;
    }

    /// <summary>
    /// Update one VoiceTone
    /// </summary>
    public async Task UpdateVoiceTone(VoiceToneWhereUniqueInput uniqueId, VoiceToneUpdateInput updateDto)
    {
        var voiceTone = updateDto.ToModel(uniqueId);



        _context.Entry(voiceTone).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.VoiceTones.Any(e => e.Id == voiceTone.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }

}
