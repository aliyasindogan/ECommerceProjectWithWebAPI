using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class AppUserType : UserType
    {
        public AppUserType()
        {
            PagePermissons = new HashSet<PagePermisson>();
            AppUsers = new HashSet<AppUser>();
        }
        public string UserTypeName { get; set; }//UserTypeName
        public ICollection<PagePermisson> PagePermissons { get; set; }
        public ICollection<AppUser> AppUsers { get; set; }

    }
}
