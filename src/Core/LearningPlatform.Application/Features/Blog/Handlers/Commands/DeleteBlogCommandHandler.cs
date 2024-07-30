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
public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogRequest, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    public DeleteBlogCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<BaseCommandResponse> Handle(DeleteBlogRequest request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.BlogRepository;
        var validator = new DeleteBlogDtoValidator();
        var dto = request.DeleteBlogDto;
        var validationresult = await validator.ValidateAsync(dto, cancellationToken);
        if (!validationresult.IsValid)
        {
            return new BaseCommandResponse()
            {
                Success = false,
                Errors = validationresult.Errors.Select(x => x.ErrorMessage)
            };
        }
        var blog = await repo.GetAsync(dto.Id);
        if (blog is null)
        {
            return new BaseCommandResponse()
            {
                Success = false,
                Message = "بلاگ با این شناسه وجود ندارد"
            };
        }
        await repo.DeleteAsync(dto.Id, cancellationToken);
        await _unitOfWork.Save();
        return new BaseCommandResponse()
        {
            Id = blog.Id,
            Success = true
        };
    }
}