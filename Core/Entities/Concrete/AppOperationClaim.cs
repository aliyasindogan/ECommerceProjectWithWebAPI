using Core.Entities.BaseEntities;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class AppOperationClaim : BaseEntity
    {
        #region Constroctor
        public AppOperationClaim()
        {
            AppUserTypeAppOperationClaims = new HashSet<AppUserTypeAppOperationClaim>();
        }
        #endregion

        #region Properties
        public string Name { get; set; }
        #endregion

        #region Relationships
        public virtual ICollection<AppUserTypeAppOperationClaim> AppUserTypeAppOperationClaims { get; set; } 
        #endregion
    }
}
