using Microsoft.AspNetCore.Mvc;
using .APIs.Common;
using .Infrastructure.Models;

namespace .APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class BusinessAccountFindManyArgs : FindManyInput<BusinessAccount, BusinessAccountWhereInput>
{
}
