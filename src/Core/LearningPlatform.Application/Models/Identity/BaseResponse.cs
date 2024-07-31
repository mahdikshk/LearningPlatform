using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.Application.Models.Identity;
public class BaseResponse
{
    public bool HasError { get; set; } = false;
    public string? Error { get; set; }
}
