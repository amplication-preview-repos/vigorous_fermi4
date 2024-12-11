using Microsoft.AspNetCore.Mvc;

namespace .APIs;

[ApiController()]
public class DigitalHumanStatsItemsController : DigitalHumanStatsItemsControllerBase
{
    public DigitalHumanStatsItemsController(IDigitalHumanStatsItemsService service) : base(service)
    {
    }

}
