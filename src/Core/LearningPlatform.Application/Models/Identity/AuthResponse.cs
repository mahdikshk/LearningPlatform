using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LearningPlatform.Application.Models.Identity
{
    public class AuthResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public bool HasError { get; set; } = false;
        public string? Error { get; set; }
    }
}
