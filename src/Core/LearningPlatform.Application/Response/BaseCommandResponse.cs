using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.Application.Response;
public class BaseCommandResponse
{
    public int Id { get; set; }
    public bool Success { get; set; }
    public string Message { get; set; }
    public IEnumerable<string> Errors { get; set; } = Enumerable.Empty<string>();
}
