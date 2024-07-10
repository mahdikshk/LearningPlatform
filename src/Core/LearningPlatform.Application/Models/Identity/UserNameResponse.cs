namespace LearningPlatform.Application.Models.Identity;

public class UserNameResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool HasError { get; set; }
    public string ErrorMessage { get; set; }
}