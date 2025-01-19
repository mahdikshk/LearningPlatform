using System;
using System.Collections.Generic;
using System.Text;

namespace LearningPlatform.Application.Models.Identity
{
    public class AuthRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
