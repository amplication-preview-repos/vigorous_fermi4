using .Infrastructure;

namespace .APIs;

public class DigitalHumenService : DigitalHumenServiceBase
{
    public DigitalHumenService(DbContext context) : base(context)
    {
    }

}
