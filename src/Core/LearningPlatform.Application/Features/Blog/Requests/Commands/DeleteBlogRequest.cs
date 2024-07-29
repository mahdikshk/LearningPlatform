using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.DTO.BlogDTOs;
using LearningPlatform.Application.Response;
using MediatR;

namespace LearningPlatform.Application.Features.Blog.Requests.Commands;
public class DeleteBlogRequest : IRequest<BaseCommandResponse>
{
    public DeleteBlogDto DeleteBlogDto { get; set; }
}
