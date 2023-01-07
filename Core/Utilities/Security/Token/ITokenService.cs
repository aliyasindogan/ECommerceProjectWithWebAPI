using Core.Entities.Concrete;
using Core.Entities.Dtos;
using System.Collections.Generic;

namespace Core.Utilities.Security.Token
{
    public interface ITokenService
    {
        AccessToken CreateToken(User user, List<OperationClaimDto> roles);
    }
}