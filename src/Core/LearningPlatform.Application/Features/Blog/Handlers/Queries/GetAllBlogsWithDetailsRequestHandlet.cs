using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Application.DTO.BlogDTOs;
using LearningPlatform.Application.Features.Blog.Requests.Queries;
using LearningPlatform.Domain;
using MediatR;

namespace LearningPlatform.Application.Features.Blog.Handlers.Queries;
internal class GetAllBlogsWithDetailsRequestHandlet : IStreamRequestHandler<GetAllBlogsWithDetailsRequest, BlogDtoWithDetails>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetAllBlogsWithDetailsRequestHandlet(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async IAsyncEnumerable<BlogDtoWithDetails> Handle(GetAllBlogsWithDetailsRequest request,
        CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.BlogRepository;
        var blogs = await repo.GetAllWithDetailsAsync();
        foreach (var blog in blogs)
        {
            var dto = _mapper.Map<BlogDtoWithDetails>(blog);
            yield return dto;
        }
    }
}
