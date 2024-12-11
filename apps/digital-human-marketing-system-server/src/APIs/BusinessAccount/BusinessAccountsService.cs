using .Infrastructure;

namespace .APIs;

public class BusinessAccountsService : BusinessAccountsServiceBase
{
    public BusinessAccountsService(DbContext context) : base(context)
    {
    }

}
