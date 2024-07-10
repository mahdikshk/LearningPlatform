namespace LearningPlatform.Application.Models.Identity;

public class LockOutResponse
{
    public bool IsSuccessfull { get; set; }
    public bool HasError { get; set; } = false;
    public string ErrorMessage { get; set; }
}