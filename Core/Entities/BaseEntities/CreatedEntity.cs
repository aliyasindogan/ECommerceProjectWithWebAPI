using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.BaseEntities
{
    public class CreatedEntity: ICreatedEntity
    {
        public int CreatedUserId { get; set; }
        [Column(TypeName = "DateTime")]
        public DateTime CreatedDate { get; set; }
    }
}
