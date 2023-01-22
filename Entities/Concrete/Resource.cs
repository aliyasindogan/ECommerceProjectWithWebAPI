using Core.Entities.BaseEntities;
using System;

namespace Entities.Concrete
{
    public class Resource : AuditEntity
    {
        public Guid ResourceName { get; set; }
        public string ResourceValue { get; set; }
        public string ResourceGroup { get; set; }

        public int LanguageID { get; set; }
        public Language Language { get; set; }
    }
}
