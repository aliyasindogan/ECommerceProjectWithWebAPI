using System;

namespace Core.Entities.BaseEntities
{
    public class AuditEntity : BaseEntity, ICreatedEntity, IUpdatedEntity, ISoftDeleteEntity
    {
        public int CreatedUserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }=false;
        public int? DeletedUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}