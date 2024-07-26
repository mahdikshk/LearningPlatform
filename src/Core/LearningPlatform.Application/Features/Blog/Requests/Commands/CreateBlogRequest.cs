using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.DTO.BlogDTOs;
using MediatR;

namespace LearningPlatform.Application.Features.Blog.Requests.Commands;
public class CreateBlogRequest : IRequest<int>
{
    public CreateBlogDTO BlogDTO { get; set; }
}
