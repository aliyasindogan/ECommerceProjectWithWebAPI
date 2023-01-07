using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class AppOperationClaim : OperationClaim
    {
        public AppOperationClaim()
        {
            PagePermissons = new HashSet<PagePermisson>();
        }
        public ICollection<PagePermisson> PagePermissons { get; set; }

    }
}
