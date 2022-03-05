using Core.Entities.BaseEntities;
using System;

namespace Core.Entities.Concrete
{
    public class UserOperationClaim : BaseEntity, IUpdatedEntity
    {
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
