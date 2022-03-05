using Core.Entities.BaseEntities;
using System;

namespace Core.Entities.Concrete
{
    public class UserTypeOperationClaim : BaseEntity, IUpdatedEntity
    {
        public int UserTypeId { get; set; }
        public int OperationClaimId { get; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
