using System;

namespace Core.Entities
{
    public interface ISoftDeleteEntity
    {
        bool IsDeleted { get; set; }
        int? DeletedUserId { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}
