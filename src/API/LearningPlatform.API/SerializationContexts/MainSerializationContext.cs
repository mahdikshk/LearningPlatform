using System.Text.Json.Serialization;
using LearningPlatform.Application.Models.Identity;

namespace LearningPlatform.API.SerializationContexts;

[JsonSerializable(typeof(AuthRequest))]
[JsonSerializable(typeof(AuthResponse))]
[JsonSerializable(typeof(BaseResponse))]
[JsonSerializable(typeof(JwtSettings))]
[JsonSerializable(typeof(LockOutRequest))]
[JsonSerializable(typeof(LockOutResponse))]
[JsonSerializable(typeof(RegistrationRequest))]
[JsonSerializable(typeof(RegistrationResponse))]
[JsonSerializable(typeof(UserExistanceRequest))]
[JsonSerializable(typeof(UserExistanceResponse))]
[JsonSerializable(typeof(UserNameRequest))]
[JsonSerializable(typeof(UserNameResponse))]

public partial class MainSerializationContext : JsonSerializerContext
{
}
