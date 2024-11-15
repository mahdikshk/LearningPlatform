namespace LearningPlatform.LiveChat.Models;

public class Media : BaseEntity
{
    public string Name { get; set; }
    public string Path { get; set; }
    public int Message_Id { get; set; }
    public Message Message { get; set; }
    public Guid MediaTypeId { get; set; }
    public MediaType MediaType { get; set; }
}