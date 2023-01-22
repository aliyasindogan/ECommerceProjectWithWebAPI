using Core.Entities.BaseEntities;
using Core.Entities.Enums;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class Resource : AuditEntity
    {
        public Resource()
        {
            AppUserTypes = new HashSet<AppUserType>();
        }
        public string ResourceValue { get; set; }
        public string ResourceGroup { get; set; }

        public int LanguageID { get; set; }
        public Language Language { get; set; }
        public ICollection<AppUserType> AppUserTypes { get; set; }
    }
}
