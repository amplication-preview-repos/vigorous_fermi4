using Microsoft.AspNetCore.Mvc;

namespace .APIs;

[ApiController()]
public class MarketingProductsController : MarketingProductsControllerBase
{
    public MarketingProductsController(IMarketingProductsService service) : base(service)
    {
    }

}
