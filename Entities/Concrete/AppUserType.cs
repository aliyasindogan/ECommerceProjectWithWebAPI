using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class AppUserType : UserType
    {
        public AppUserType()
        {
            PagePermissons = new HashSet<PagePermisson>();
        }
        public ICollection<PagePermisson> PagePermissons { get; set; }

    }
}
