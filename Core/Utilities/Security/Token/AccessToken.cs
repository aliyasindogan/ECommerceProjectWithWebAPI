using System;

namespace Core.Utilities.Security.Token
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int UserTypeID { get; set; }
        public string UserTypeName { get; set; }
        public string ImageUrl { get; set; }
        public string FullName { get; set; }
    }
}