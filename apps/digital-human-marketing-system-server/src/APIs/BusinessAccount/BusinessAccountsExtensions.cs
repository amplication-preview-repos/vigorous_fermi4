using .APIs.Dtos;
using .Infrastructure.Models;

namespace .APIs.Extensions;

public static class BusinessAccountsExtensions
{
    public static BusinessAccount ToDto(this BusinessAccountDbModel model)
    {
        return new BusinessAccount
        {
            BusinessName = model.BusinessName,
            ContactEmail = model.ContactEmail,
            ContactPhone = model.ContactPhone,
            CreatedAt = model.CreatedAt,
            DigitalHumen = model.DigitalHumen?.Select(x => x.Id).ToList(),
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,

        };
    }

    public static BusinessAccountDbModel ToModel(this BusinessAccountUpdateInput updateDto, BusinessAccountWhereUniqueInput uniqueId)
    {
        var businessAccount = new BusinessAccountDbModel
        {
            Id = uniqueId.Id,
            BusinessName = updateDto.BusinessName,
            ContactEmail = updateDto.ContactEmail,
            ContactPhone = updateDto.ContactPhone
        };

        if (updateDto.CreatedAt != null)
        {
            businessAccount.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            businessAccount.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return businessAccount;
    }

}
