using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Core.Extensions
{
    public  static class ClaimExtensions
    {
        /// <summary>
        /// Email
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="email"></param>
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }
        /// <summary>
        /// Ad Soyad
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="name"></param>
        public static void AddFullName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }
        /// <summary>
        /// User ID
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="nameIdentifier"></param>
        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentifier));
        }
        /// <summary>
        /// Roller
        /// </summary>
        /// <param name="claims"></param>
        /// <param name="roles"></param>
        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}
