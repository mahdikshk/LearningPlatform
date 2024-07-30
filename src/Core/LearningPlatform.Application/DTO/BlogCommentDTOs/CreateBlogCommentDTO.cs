using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Domain;

namespace LearningPlatform.Application.DTO.BlogCommentDTOs;
public class CreateBlogCommentDTO
{
    public int UserId { get; set; }
    public int BlogId { get; set; }
    public string Text { get; set; }
}
