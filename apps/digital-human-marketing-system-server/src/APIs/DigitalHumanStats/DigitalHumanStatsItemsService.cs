using .Infrastructure;

namespace .APIs;

public class DigitalHumanStatsItemsService : DigitalHumanStatsItemsServiceBase
{
    public DigitalHumanStatsItemsService(DbContext context) : base(context)
    {
    }

}
