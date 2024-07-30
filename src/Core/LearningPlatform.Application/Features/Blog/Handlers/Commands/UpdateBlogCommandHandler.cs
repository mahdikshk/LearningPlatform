using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Application.DTO.BlogDTOs.Validators;
using LearningPlatform.Application.Features.Blog.Requests.Commands;
using LearningPlatform.Application.Response;
using MediatR;

namespace LearningPlatform.Application.Features.Blog.Handlers.Commands;
public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogRequest,BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public UpdateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(UpdateBlogRequest request, CancellationToken cancellationToken)
    {
        var blogrepo = _unitOfWork.BlogRepository;
        var validator = new UpdateBlogDtoValidator();
        var result = await validator.ValidateAsync(request.UpdateBlogDTO, cancellationToken);
        if (!result.IsValid)
        {
            var response = new BaseCommandResponse()
            {
                Success = false,
                Message = "آپدیت کردن بلاگ با مشکل مواجه شده است",
                Errors = result.Errors.Select(x=>x.ErrorMessage)
            };
            return response;
        }
        var blog = await blogrepo.GetAsync(request.UpdateBlogDTO.Id);
        if (blog is null)
        {
            var response = new BaseCommandResponse() 
            {
                Success = false,
                Message = "پستی با این شناسه وجود ندارد",
            };
            return response;
        }
        else
        {
            blog.Text = request.UpdateBlogDTO.Text;
            blog.Title = request.UpdateBlogDTO.Title;
        }
        await blogrepo.UpdateAsync(blog,cancellationToken);
        await _unitOfWork.Save();
        return new BaseCommandResponse()
        {
            Success = true,
            Id = blog.Id,
        };
    }
}
