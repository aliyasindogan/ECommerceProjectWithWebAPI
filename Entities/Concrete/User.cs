using Core.Entity.Concrete;
using System;

namespace Entities.Concrete
{
    public class User : AuditableEntity
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public bool Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpireDate { get; set; }
    }
}