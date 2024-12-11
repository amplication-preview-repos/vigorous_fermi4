using Microsoft.AspNetCore.Mvc;

namespace .APIs;

[ApiController()]
public class VoiceTonesController : VoiceTonesControllerBase
{
    public VoiceTonesController(IVoiceTonesService service) : base(service)
    {
    }

}
