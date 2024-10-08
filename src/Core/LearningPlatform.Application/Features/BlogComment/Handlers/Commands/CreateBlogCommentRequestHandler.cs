﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using LearningPlatform.Application.Contracts.Identity;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Application.DTO.BlogCommentDTOs;
using LearningPlatform.Application.DTO.BlogCommentDTOs.Validators;
using LearningPlatform.Application.Features.BlogComment.Requests.Commands;
using LearningPlatform.Application.Models.Identity;
using LearningPlatform.Application.Response;
using LearningPlatform.Domain;
using MediatR;

namespace LearningPlatform.Application.Features.BlogComment.Handlers.Commands;
internal class CreateBlogCommentRequestHandler : IRequestHandler<CreateBlogCommentRequest, BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    public CreateBlogCommentRequestHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userService = userService;
    }

    public async Task<BaseCommandResponse> Handle(CreateBlogCommentRequest request, CancellationToken cancellationToken)
    {
        var blogRepo = _unitOfWork.BlogRepository;
        var commentRepo = _unitOfWork.BlogCommentRepository;
        var validator = new CreateBlogCommentDtoValidator();
        var validationresult = await validator.ValidateAsync(request.CreateBlogCommentDTO, cancellationToken);
        if (!validationresult.IsValid)
        {
            return new BaseCommandResponse
            {
                Success = false,
                Message = "یک یا چند فیلد به اشتباه وارد شده اند",
                Errors = validationresult.Errors.Select(x => x.ErrorMessage)
            };
        }
        var blog = await blogRepo.GetByIdWithDetailsAsync(request.CreateBlogCommentDTO.BlogId);
        if (blog is null)
        {
            return new BaseCommandResponse
            {
                Success = false,
                Message = "بلاگ وارد شده وجود ندارد"
            };
        }
        var existanceRequest = new UserExistanceRequest()
        {
            UserId = request.CreateBlogCommentDTO.UserId
        };
        var userExistanceResult = await _userService.GetUserExistanceState(existanceRequest);
        if (!userExistanceResult.Exists || userExistanceResult.HasError)
        {
            return new BaseCommandResponse()
            {
                Success = false,
                Message = "کاربر مورد نظر وجود ندارد"
            };
        }
        var comment = _mapper.Map<Domain.BlogComment>(request.CreateBlogCommentDTO);
        blog.Comments.Add(comment);
        await _unitOfWork.Save();
        return new BaseCommandResponse
        {
            Id = comment.Id,
            Success = true
        };
    }
}
