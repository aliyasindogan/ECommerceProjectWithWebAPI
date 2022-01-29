using System;

namespace Core.Entities.BaseEntities
{
    public class UpdatedEntity : IUpdatedEntity
    {
        public int? UpdatedUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
