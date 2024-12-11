using Microsoft.AspNetCore.Mvc;

namespace .APIs;

[ApiController()]
public class DigitalHumanKnowledgeBasesController : DigitalHumanKnowledgeBasesControllerBase
{
    public DigitalHumanKnowledgeBasesController(IDigitalHumanKnowledgeBasesService service) : base(service)
    {
    }

}
