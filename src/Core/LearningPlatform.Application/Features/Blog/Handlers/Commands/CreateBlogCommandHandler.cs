using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.Features.Blog.Requests.Commands;


using MediatR;
using LearningPlatform.Application.Contracts.Persistance;
using AutoMapper;
using LearningPlatform.Application.DTO.BlogDTOs.Validators;
using LearningPlatform.Application.Response;
using LearningPlatform.Application.Contracts.Identity;

namespace LearningPlatform.Application.Features.Blog.Handlers.Commands;
public class CreateBlogCommandHandler : IRequestHandler<CreateBlogRequest,BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public CreateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper, IUserService userService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _userService = userService;
    }
    public async Task<BaseCommandResponse> Handle(CreateBlogRequest request, CancellationToken cancellationToken)
    {
        var blogrepository = _unitOfWork.BlogRepository;
        var validator = new CreateBlogDtoValidator();
        var validationResult = await validator.ValidateAsync(request.BlogDTO,cancellationToken);
        if(!validationResult.IsValid)
        {
            var response = new BaseCommandResponse()
            {
                Success = false,
                Message = "ساخت بلاگ با مشکل مواجه شد",
                Errors = validationResult.Errors.Select(x => x.ErrorMessage),
            };
            return response;
        }
        var blog = _mapper.Map<Domain.Blog>(request.BlogDTO);
        var userExistanceResult = await _userService.GetUserExistanceState(new Models.Identity.UserExistanceRequest()
        {
            UserId = request.BlogDTO.Writer_Id
        });
        if(!userExistanceResult.Exists)
        {
            return new BaseCommandResponse()
            {
                Success = false,
                Message = "کاربر مورد نظر وجود ندارد"
            };
        }
        await blogrepository.AddAsync(blog, cancellationToken);
        await _unitOfWork.Save();
        return new BaseCommandResponse
        {
            Id = blog.Id,
            Success = true,
        };
    }
}
