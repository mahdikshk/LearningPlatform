﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.Application.Models.Identity;
public class UserExistanceRequest
{
    public string UserId { get; set; }
    public string Email { get; set; }
}