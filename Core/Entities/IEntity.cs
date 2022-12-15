namespace Core.Entities
{
    /// <summary>
    /// Veritabanında karşılık gelen tablolarda olacak
    /// </summary>
    public interface IEntity
    {
        int Id { get; set; }
        bool IsActive { get; set; }
    }
}