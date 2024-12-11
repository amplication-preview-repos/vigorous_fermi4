using .Infrastructure;

namespace .APIs;

public class DigitalHumanKnowledgeBasesService : DigitalHumanKnowledgeBasesServiceBase
{
    public DigitalHumanKnowledgeBasesService(DbContext context) : base(context)
    {
    }

}
