using Core.Entities.BaseEntities;

namespace Entities.Concrete
{
    public class PagePermisson:AuditEntity
    {
        public int AppUserTypeID { get; set; }
        public int PageID { get; set; }
    }
}
