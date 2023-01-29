using Core.Entities.BaseEntities;

namespace Entities.Concrete
{
    public class ResourceDetail:AuditEntity
    {
        //ID
        public int ResourceID { get; set; }
        //System Admin/en name
        public string ResourceValue { get; set; }
        //tr/en
        public int LanguageID { get; set; }
        public Language Language { get; set; }
        public Resource Resource { get; set; }
    }
}
