using Core.Entities.BaseEntities;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class AppUserType : CreatedUpdatedDeletedEntity
    {
        #region Constroctor
        public AppUserType()
        {
            AppUsers = new HashSet<AppUser>();
            AppUserTypeAppOperationClaims = new HashSet<AppUserTypeAppOperationClaim>();

        }
        #endregion

        #region Properties
        public string AppUserTypeName { get; set; }
        #endregion

        #region Relationships
        public virtual ICollection<AppUser> AppUsers { get; set; }
        public virtual ICollection<AppUserTypeAppOperationClaim> AppUserTypeAppOperationClaims { get; set; }

        #endregion
    }
}
