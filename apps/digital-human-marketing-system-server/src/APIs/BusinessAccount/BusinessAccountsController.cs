using Microsoft.AspNetCore.Mvc;

namespace .APIs;

[ApiController()]
public class BusinessAccountsController : BusinessAccountsControllerBase
{
    public BusinessAccountsController(IBusinessAccountsService service) : base(service)
    {
    }

}
