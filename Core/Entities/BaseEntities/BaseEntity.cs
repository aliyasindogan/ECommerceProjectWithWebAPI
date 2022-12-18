namespace Core.Entities.BaseEntities
{
    public class BaseEntity : IEntity
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }=true;
    }
}