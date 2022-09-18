using Core.Entities.BaseEntities;
using Core.Entities.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Concrete
{
    public class AppUserTypeAppOperationClaim : BaseEntity, IUpdatedEntity
    {
        #region Properties
        public int AppUserTypeID { get; set; }
        public int AppOperationClaimID { get; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
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
