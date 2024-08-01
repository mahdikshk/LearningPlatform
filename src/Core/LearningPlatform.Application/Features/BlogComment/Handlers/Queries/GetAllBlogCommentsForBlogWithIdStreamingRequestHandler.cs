using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LearningPlatform.Application.Contracts.Identity;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Application.DTO.BlogCommentDTOs;
using LearningPlatform.Application.Features.BlogComment.Requests.Queries;
using LearningPlatform.Application.Models.Identity;
using MediatR;

namespace LearningPlatform.Application.Features.BlogComment.Handlers.Queries;
internal class GetAllBlogCommentsForBlogWithIdStreamingRequestHandler : IStreamRequestHandler<GetAllBlogCommentsForBlogWithIdStreamingRequest,
    BlogCommentDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    public GetAllBlogCommentsForBlogWithIdStreamingRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userService = userService;
    }
    public async IAsyncEnumerable<BlogCommentDTO> Handle(GetAllBlogCommentsForBlogWithIdStreamingRequest request,
        CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.BlogCommentRepository;
        var userNameRequest = new UserNameRequest();
        await foreach (var comment in repo.GetAllForBlogWithIdStreaming(request.BlogId))
        {
            if(cancellationToken.IsCancellationRequested)
                yield break;
            userNameRequest.Id = comment.UserId;
            var userNameResponse = await _userService.GetFirstNameAndLastName(userNameRequest);
            var dto = _mapper.Map<BlogCommentDTO>(comment);
            dto.UserName = userNameResponse.FirstName + " " + userNameResponse.LastName;
            yield return dto;
        }
    }
}
