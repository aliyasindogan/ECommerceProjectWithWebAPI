using Core.Entities.BaseEntities;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Concrete
{
    public class AppUser : CreatedUpdatedDeletedEntity
    {
        #region Properties
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Email { get; set; }
        public string ProfileImageUrl { get; set; }
        public string GsmNumber { get; set; }
        public Guid RefreshToken { get; set; }
        public int AppUserTypeID { get; set; }
        #endregion

        #region Relationships
        [ForeignKey("AppUserTypeID")]
        public virtual AppUserType AppUserType { get; set; } 
        #endregion
    }
}
