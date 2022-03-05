using System.Collections.Generic;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class AppOperationClaim : OperationClaim
    {
        public AppOperationClaim()
        {
            AppUserAppOperationClaims = new HashSet<AppUserAppOperationClaim>();
        }
        public virtual ICollection<AppUserAppOperationClaim> AppUserAppOperationClaims { get; set; }
    }
}
