using System;

namespace Core.Utilities.Security.Token
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public int AppUserID { get; set; }
        public string UserName { get; set; }
        public int AppUserTypeID { get; set; }
        public string AppUserTypeName { get; set; }
        public string ImageUrl { get; set; }
        public string FullName { get; set; }
    }
}