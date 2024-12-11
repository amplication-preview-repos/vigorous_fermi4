using .APIs.Dtos;
using .APIs.Common;

namespace .APIs;

public interface IDigitalHumanKnowledgeBasesService
{
    /// <summary>
    /// Create one DigitalHumanKnowledgeBase
    /// </summary>
    public Task<DigitalHumanKnowledgeBase> CreateDigitalHumanKnowledgeBase(DigitalHumanKnowledgeBaseCreateInput digitalhumanknowledgebase);
    /// <summary>
    /// Delete one DigitalHumanKnowledgeBase
    /// </summary>
    public Task DeleteDigitalHumanKnowledgeBase(DigitalHumanKnowledgeBaseWhereUniqueInput uniqueId);
    /// <summary>
    /// Find many DigitalHumanKnowledgeBases
    /// </summary>
    public Task<List<DigitalHumanKnowledgeBase>> DigitalHumanKnowledgeBases(DigitalHumanKnowledgeBaseFindManyArgs findManyArgs);
    /// <summary>
    /// Meta data about DigitalHumanKnowledgeBase records
    /// </summary>
    public Task<MetadataDto> DigitalHumanKnowledgeBasesMeta(DigitalHumanKnowledgeBaseFindManyArgs findManyArgs);
    /// <summary>
    /// Get one DigitalHumanKnowledgeBase
    /// </summary>
    public Task<DigitalHumanKnowledgeBase> DigitalHumanKnowledgeBase(DigitalHumanKnowledgeBaseWhereUniqueInput uniqueId);
    /// <summary>
    /// Update one DigitalHumanKnowledgeBase
    /// </summary>
    public Task UpdateDigitalHumanKnowledgeBase(DigitalHumanKnowledgeBaseWhereUniqueInput uniqueId, DigitalHumanKnowledgeBaseUpdateInput updateDto);
    /// <summary>
    /// Get a DigitalHuman record for DigitalHumanKnowledgeBase
    /// </summary>
    public Task<DigitalHuman> GetDigitalHuman(DigitalHumanKnowledgeBaseWhereUniqueInput uniqueId);
}
