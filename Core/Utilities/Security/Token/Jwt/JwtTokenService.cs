using Core.Entities.Concrete;
using Core.Entities.Dtos;
using Core.Utilities.Messages;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Core.Utilities.Security.Token.Jwt
{
    public class JwtTokenService : ITokenService
    {
        private readonly AppSettings _appSettings;

        public JwtTokenService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public AccessToken CreateToken(User user, List<OperationClaimDto> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecurityKey);

            ClaimsIdentity identity = null;
            identity = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                    new Claim(ClaimTypes.Name,user.FirstName + " " +user.LastName),
                    new Claim(ClaimTypes.Email,user.Email),
                });
            foreach (var item in roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, item.Name));
            }

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = identity,
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AccessToken()
            {
                Token = tokenHandler.WriteToken(token),
                Expiration = (DateTime)tokenDescriptor.Expires,
                UserName = user.UserName,
                AppUserID = user.Id,
                FullName = user.FirstName + " " + user.LastName,
                ImageUrl = user.ProfileImageUrl,
                AppUserTypeID = user.UserTypeID,
                AppUserTypeName = user.UserTypeID == 1 ? Constants.SystemAdmin : Constants.Admin,
            };
        }

    }
}