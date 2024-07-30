using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Application.DTO.BlogDTOs;
using LearningPlatform.Application.Features.Blog.Requests.Queries;
using MediatR;

namespace LearningPlatform.Application.Features.Blog.Handlers.Queries;
internal class GetBlogByIdWithDetailsRequestHandler : IRequestHandler<GetBlogByIdWithDetailsRequest, BlogDtoWithDetails>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetBlogByIdWithDetailsRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BlogDtoWithDetails> Handle(GetBlogByIdWithDetailsRequest request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.BlogRepository;
        var blog = await repo.GetByIdWithDetailsAsync(request.Id);
        var dto = _mapper.Map<BlogDtoWithDetails>(blog);
        return dto;
    }
}
