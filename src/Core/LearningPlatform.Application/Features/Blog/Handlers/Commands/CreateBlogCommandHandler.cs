using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.Features.Blog.Requests.Commands;


using MediatR;
using LearningPlatform.Application.Contracts.Persistance;
using AutoMapper;

namespace LearningPlatform.Application.Features.Blog.Handlers.Commands;
internal class CreateBlogCommandHandler : IRequestHandler<CreateBlogRequest,int>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }
    public async Task<int> Handle(CreateBlogRequest request, CancellationToken cancellationToken)
    {
        var blogrepository = _unitOfWork.BlogRepository;
        var blog = _mapper.Map<Domain.Blog>(request.BlogDTO);
        await blogrepository.AddAsync(blog, cancellationToken);
        return blog.Id;
    }
}
