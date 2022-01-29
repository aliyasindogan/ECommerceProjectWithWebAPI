using Core.Entities.BaseEntities;
using System;

namespace Core.Entities.Concrete
{
    public class UserRole : BaseEntity, IUpdatedEntity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
