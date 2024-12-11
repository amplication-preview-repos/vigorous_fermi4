using .Infrastructure;

namespace .APIs;

public class VoiceTonesService : VoiceTonesServiceBase
{
    public VoiceTonesService(DbContext context) : base(context)
    {
    }

}
