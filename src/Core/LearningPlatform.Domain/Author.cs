using LearningPlatform.Domain.Common;

namespace LearningPlatform.Domain;

public class Author : BaseDomainEntity
{
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? AuthorWebsite { get; set; }
    public string? AuthorEmail { get; set; }
    public string? AuthorPhone { get; set; }
    public string AuthorUserId { get; set; } = null!;
    public ICollection<Course>? Courses { get; set; } = null!;
}