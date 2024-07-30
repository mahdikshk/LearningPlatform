using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Application.DTO.BlogCommentDTOs.Validators;
using LearningPlatform.Application.Features.BlogComment.Requests.Commands;
using LearningPlatform.Application.Response;
using MediatR;

namespace LearningPlatform.Application.Features.BlogComment.Handlers.Commands;
internal class UpdateBlogCommentRequestHandler : IRequestHandler<UpdateBlogCommentRequest, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    public UpdateBlogCommentRequestHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BaseCommandResponse> Handle(UpdateBlogCommentRequest request, CancellationToken cancellationToken)
    {
        var dto = request.UpdateBlogCommentDto;
        var repo = _unitOfWork.BlogCommentRepository;
        var validator = new UpdateBlogCommentDtoValidator();
        var result = await validator.ValidateAsync(request.UpdateBlogCommentDto, cancellationToken);
        if (!result.IsValid)
        {
            return new BaseCommandResponse
            {
                Id = request.UpdateBlogCommentDto.Id,
                Message = "مشکلی در آپدیت کردن این کامنت بوجود آمده",
                Errors = result.Errors.Select(x=>x.ErrorMessage),
                Success = false
            };
        }
        var comment = await repo.GetAsync(request.UpdateBlogCommentDto.Id);
        if(comment is null)
        {
            return new BaseCommandResponse
            {
                Success = false,
                Id = dto.Id,
                Message = "این کامنت وجود ندارد"
            };
        }
        comment.Text = dto.Text;
        await repo.UpdateAsync(comment, cancellationToken);
        return new BaseCommandResponse
        {
            Id = dto.Id,
            Success = true,
        };
    }
}