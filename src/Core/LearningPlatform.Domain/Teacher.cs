using LearningPlatform.Domain.Common;

namespace LearningPlatform.Domain;

public class Teacher : BaseDomainEntity
{
    public string Description { get; set; } = null!;
    public string? TeacherWebsite { get; set; }
    public string? TeacherEmail { get; set; }
    public string? TeacherPhone { get; set; }
    public string TeacherUserId { get; set; } = null!;
    public ApplicationUser TeacherUser { get; set; }
    public ICollection<Course>? Courses { get; set; } = null!;
}