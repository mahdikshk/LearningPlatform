using System;
using System.Collections.Generic;
using System.Text;

namespace LearningPlatform.Application.Models.Identity
{
    public class RegistrationResponse
    {
        public string UserId { get; set; }
        public bool HasError { get; set; }
        public string Error { get; set; }
    }
}
