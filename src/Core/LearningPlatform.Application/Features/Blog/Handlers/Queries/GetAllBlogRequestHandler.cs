using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Application.DTO.BlogDTOs;
using LearningPlatform.Application.Features.Blog.Requests.Queries;
using MediatR;

namespace LearningPlatform.Application.Features.Blog.Handlers.Queries;
internal class GetAllBlogRequestHandler : IStreamRequestHandler<GetAllBlogsRequest,BlogDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllBlogRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async IAsyncEnumerable<BlogDTO> Handle(GetAllBlogsRequest request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.BlogRepository;
        var blogs = await repo.GetAllAsync(cancellationToken);
        foreach (var blog in blogs)
        {
            var dto = _mapper.Map<BlogDTO>(blog);
            yield return dto;
        }
    }
}
