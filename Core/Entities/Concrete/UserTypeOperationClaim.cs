using Core.Entities.BaseEntities;

namespace Core.Entities.Concrete
{
    public class UserTypeOperationClaim : AuditEntity
    {
        public int AUserTypeID { get; set; }
        public int OperationClaimID { get; set; }
        public string Status { get; set; }
    }
}
