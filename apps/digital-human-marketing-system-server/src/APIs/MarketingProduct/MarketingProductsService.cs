using .Infrastructure;

namespace .APIs;

public class MarketingProductsService : MarketingProductsServiceBase
{
    public MarketingProductsService(DbContext context) : base(context)
    {
    }

}
