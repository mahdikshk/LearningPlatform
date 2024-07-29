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
internal class GetBlogByIdRequestHandler : IRequestHandler<GetBlogByIdRequest, BlogDTO>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public GetBlogByIdRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BlogDTO> Handle(GetBlogByIdRequest request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.BlogRepository;
        var id = request.Id;
        var blog = await repo.GetAsync(id);
        var dto = _mapper.Map<BlogDTO>(blog);
        return dto;
    }
}
