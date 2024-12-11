using Microsoft.AspNetCore.Mvc;

namespace .APIs;

[ApiController()]
public class DigitalHumenController : DigitalHumenControllerBase
{
    public DigitalHumenController(IDigitalHumenService service) : base(service)
    {
    }

}
