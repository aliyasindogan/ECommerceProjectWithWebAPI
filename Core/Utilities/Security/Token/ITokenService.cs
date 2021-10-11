using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Token
{
    public interface ITokenService
    {
        AccessToken CreateToken(int userId, string userName);
    }
}