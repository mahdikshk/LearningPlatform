using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.DTO.BlogCommentDTOs;
using LearningPlatform.Application.Response;
using MediatR;

namespace LearningPlatform.Application.Features.BlogComment.Requests.Commands;
public class CreateBlogCommentRequest : IRequest<BaseCommandResponse>
{
    public CreateBlogCommentDTO CreateBlogCommentDTO { get; set; }
}
