using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.DTO.BlogCommentDTOs;

namespace LearningPlatform.Application.DTO.BlogDTOs;
public class BlogDTO : IBlogDTO
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Text { get; set; }
    public string Writer_Name { get; set; }
}
