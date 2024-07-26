using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearningPlatform.Application.DTO.BlogDTOs;
public class CreateBlogDTO
{
    public string Title { get; set; }
    public string Text { get; set; }
    public string Writer_Id { get; set; }
}
