namespace Core.Entity.Abstract
{
    /// <summary>
    /// Veritabanında karşılık gelen tablolarda olacak
    /// </summary>
    public interface IEntity
    {
        int Id { get; set; }
    }
}