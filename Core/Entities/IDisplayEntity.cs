namespace Core.Entities
{
    public interface IDisplayEntity
    {
        int DisplayOrder { get; set; }
        bool IsDisplay { get; set; }
    }
}