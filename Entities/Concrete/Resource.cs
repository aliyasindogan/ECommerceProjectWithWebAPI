using Core.Entities.BaseEntities;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Resource : AuditEntity
    {
        public Resource()
        {
            AppUserTypes = new HashSet<AppUserType>();
        }
        public string ResourceName { get; set; }

        public ICollection<AppUserType> AppUserTypes { get; set; }
    }
}
