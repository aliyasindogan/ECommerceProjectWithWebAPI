namespace Entities.Dtos.Auth
{
    public class LoginDto
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsRememberMe { get; set; }
    }
}