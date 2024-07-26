using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Application.Features.Blog.Requests.Commands;
using MediatR;

namespace LearningPlatform.Application.Features.Blog.Handlers.Commands;
internal class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogRequest>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task Handle(UpdateBlogRequest request, CancellationToken cancellationToken)
    {
        var blogrepo = _unitOfWork.BlogRepository;
        var blog = await blogrepo.GetAsync(request.UpdateBlogDTO.Id);
        if (blog is null)
        {

            return;
        }
        else
        {
            blog.Text = request.UpdateBlogDTO.Text;
            blog.Title = request.UpdateBlogDTO.Title;
        }
        await blogrepo.UpdateAsync(blog,cancellationToken);
    }
}
