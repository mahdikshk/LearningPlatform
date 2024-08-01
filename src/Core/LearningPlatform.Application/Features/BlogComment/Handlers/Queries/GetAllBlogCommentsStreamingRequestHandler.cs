using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
internal class GetAllBlogCommentsStreamingRequestHandler : IStreamRequestHandler<GetAllBlogCommentsStreamingRequest, BlogCommentDTO>
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllBlogCommentsStreamingRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userService = userService;
    }
    public async IAsyncEnumerable<BlogCommentDTO> Handle(GetAllBlogCommentsStreamingRequest request,
      CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.BlogCommentRepository;
        var userNameRequest = new UserNameRequest();
        await foreach (var comment in repo.GetAllAsyncStreaming(cancellationToken))
        {
            if (cancellationToken.IsCancellationRequested)
                yield break;
            userNameRequest.Id = comment.UserId;
            var name = await _userService.GetFirstNameAndLastName(userNameRequest);
            var dto = _mapper.Map<BlogCommentDTO>(comment);
            dto.UserName = name.FirstName + " " + name.LastName;
            yield return dto;
        }
    }
}
