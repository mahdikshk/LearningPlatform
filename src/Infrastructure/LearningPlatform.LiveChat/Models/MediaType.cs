namespace LearningPlatform.LiveChat.Models;

public class MediaType : BaseEntity
{
    public string Name { get; set; }
    public ICollection<Media> Medias { get; set; }
}