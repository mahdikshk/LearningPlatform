using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.DTO.BlogDTOs;

namespace LearningPlatform.Application.DTO.BlogCommentDTOs;
public class BlogCommentDtoWithDetails
{
    public string Text { get; set; } = null!;
    public string UserId { get; set; } = null!;
    public int Blog_Id { get; set; }
    public BlogDTO BlogDTO { get; set; }
}
