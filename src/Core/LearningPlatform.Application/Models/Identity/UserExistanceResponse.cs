using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.Application.Models.Identity;
public class UserExistanceResponse : BaseResponse
{
    public bool Exists { get; set; }
}
