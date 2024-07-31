using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LearningPlatform.Application.Models.Identity
{
    public class AuthResponse : BaseResponse
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        
    }
}
