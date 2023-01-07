using Core.Entities.BaseEntities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Concrete
{
    public class AppUser : AuditEntity
    {
        #region Properties
        [Required]
        [StringLength(20)]
        public string UserName { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(500)]
        public string ProfileImageUrl { get; set; }
        [StringLength(10)]
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
