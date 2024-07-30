using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.DTO.BlogCommentDTOs;
using LearningPlatform.Application.Response;
using MediatR;

namespace LearningPlatform.Application.Features.BlogComment.Requests.Commands;
public class UpdateBlogCommentRequest : IRequest<BaseCommandResponse>
{
    public UpdateBlogCommentDto UpdateBlogCommentDto { get; set; }
}
