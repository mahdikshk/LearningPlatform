using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using LearningPlatform.Application.Contracts.Identity;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Application.DTO.BlogDTOs;
using LearningPlatform.Application.Features.Blog.Requests.Queries;
using LearningPlatform.Application.Models.Identity;
using MediatR;

namespace LearningPlatform.Application.Features.Blog.Handlers.Queries;
internal class GetAllBlogRequestHandler : IStreamRequestHandler<GetAllBlogsRequest,BlogDTO>
{
    private readonly IUserService _userService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllBlogRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userService = userService;
    }

    public async IAsyncEnumerable<BlogDTO> Handle(GetAllBlogsRequest request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.BlogRepository;
        var blogs = await repo.GetAllAsync(cancellationToken);
        UserNameRequest userNameRequest = new UserNameRequest();
        foreach (var blog in blogs)
        {
            if(cancellationToken.IsCancellationRequested) 
            { 
                 yield break;
            }
            userNameRequest.Id = blog.Writer_Id;
            var response = await _userService.GetFirstNameAndLastName(userNameRequest);
            var dto = _mapper.Map<BlogDTO>(blog);
            dto.Writer_Name = $"{response.FirstName} {response.LastName}";
            yield return dto;
        }
    }
}
