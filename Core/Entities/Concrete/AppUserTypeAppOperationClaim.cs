using Core.Entities.BaseEntities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Concrete
{
    public class AppUserTypeAppOperationClaim : AuditEntity
    {
        #region Properties
        [Required]
        public int AppUserTypeID { get; set; }
      
        [Required]
        public int AppOperationClaimID { get; set; }

        [Required]
        public string Status { get; set; }
        #endregion

        #region Relationships
        [ForeignKey("AppOperationClaimID")]
        public virtual AppOperationClaim AppOperationClaim { get; set; }

        [ForeignKey("AppUserTypeID")]
        public virtual AppUserType AppUserType { get; set; } 
        #endregion
    }
}
