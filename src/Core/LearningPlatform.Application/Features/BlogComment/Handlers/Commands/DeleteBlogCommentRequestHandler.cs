using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Application.DTO.BlogCommentDTOs.Validators;
using LearningPlatform.Application.Features.BlogComment.Requests.Commands;
using LearningPlatform.Application.Response;
using MediatR;

namespace LearningPlatform.Application.Features.BlogComment.Handlers.Commands;
internal class DeleteBlogCommentRequestHandler : IRequestHandler<DeleteBlogCommentRequest, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;

    public DeleteBlogCommentRequestHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<BaseCommandResponse> Handle(DeleteBlogCommentRequest request, CancellationToken cancellationToken)
    {
        var repo = _unitOfWork.BlogCommentRepository;
        var validator = new DeleteBlogCommentDtoValidator();
        var result = await validator.ValidateAsync(request.DeleteBlogCommentDto, cancellationToken);
        if(!result.IsValid)
        {
            return new BaseCommandResponse
            {
                Id = request.DeleteBlogCommentDto.Id,
                Success = false,
                Errors=result.Errors.Select(x=>x.ErrorMessage),
                Message = "لطفا یک شناسه معتبر انتخاب کنید"
            };
        }
        var comment = await repo.GetAsync(request.DeleteBlogCommentDto.Id);
        if (comment == null)
        {
            return new BaseCommandResponse
            {
                Id = request.DeleteBlogCommentDto.Id,
                Success = false,
                Message = "کامنت مورد نظر وجود ندارد"
            };
        }
        await repo.DeleteAsync(request.DeleteBlogCommentDto.Id,cancellationToken);
        return new BaseCommandResponse
        {
            Success = true,
        };
    }
}
