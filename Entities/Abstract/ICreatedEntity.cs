using System;

namespace Entities.Abstract
{
    public interface ICreatedEntity
    {
        int CreatedUserId { get; set; }
        DateTime CreatedDate { get; set; }
    }
}