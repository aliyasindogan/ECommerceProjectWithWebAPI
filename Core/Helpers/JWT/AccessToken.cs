using System;

namespace Core.Helpers.JWT
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
}