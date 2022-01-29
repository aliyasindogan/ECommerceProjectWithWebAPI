using System;

namespace Core.Entities
{
    public interface IUpdatedEntity
    {
        int? UpdatedUserId { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}