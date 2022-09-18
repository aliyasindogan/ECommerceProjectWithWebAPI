using Core.Entities.BaseEntities;
using System.Collections.Generic;

namespace Core.Entities.Concrete
{
    public class AppUserType : BaseEntity
    {
        #region Constroctor
        public AppUserType()
        {
            AppUsers = new HashSet<AppUser>();
        }
        #endregion

        #region Properties
        public string AppUserTypeName { get; set; }
        #endregion

        #region Relationships
        ICollection<AppUser> AppUsers { get; set; } 
        #endregion
    }
}
