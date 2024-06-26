using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain.Common;

namespace LearningPlatform.Domain;
public class Video : BaseDomainEntity
{
    public required string VideoLocation { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public string? AttachmentLocation { get; set; }
    public int Topic_Id { get; set; }
    public Topic Topic { get; set; }
}