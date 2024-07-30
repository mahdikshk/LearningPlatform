using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.DTO.BlogDTOs;
using MediatR;

namespace LearningPlatform.Application.Features.Blog.Requests.Queries;
public class GetBlogByIdWithDetailsRequest : IRequest<BlogDtoWithDetails>
{
    public int Id { get; set; }
}
