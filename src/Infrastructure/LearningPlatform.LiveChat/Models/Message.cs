using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.LiveChat.Models;
public class Message : BaseEntity
{
    public string? User_Id { get; set; }
    public string? Name { get; set; }
    public string Email { get; set; }
    public string? Text { get; set; }
    public ICollection<Media> Medias { get; set; }
}
