using Core.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class AppUser : User
    {
        public AppUser()
        {
            AppUserAppRoles = new HashSet<AppUserAppRole>();
        }
        public Guid RefreshToken { get; set; }
        public virtual ICollection<AppUserAppRole> AppUserAppRoles { get; set; }
    }
}