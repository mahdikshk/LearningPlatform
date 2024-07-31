using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.DTO.BlogCommentDTOs;
using LearningPlatform.Application.DTO.BlogDTOs;
using MediatR;

namespace LearningPlatform.Application.Features.BlogComment.Requests.Queries;
public class GetAllBlogCommentsStreamingRequest : IStreamRequest<BlogCommentDTO>
{
}
