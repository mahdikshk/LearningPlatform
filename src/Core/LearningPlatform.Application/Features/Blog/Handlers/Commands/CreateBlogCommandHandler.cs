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

namespace LearningPlatform.Application.Features.Blog.Handlers.Commands;
public class CreateBlogCommandHandler : IRequestHandler<CreateBlogRequest,BaseCommandResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CreateBlogCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
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
        await blogrepository.AddAsync(blog, cancellationToken);
        return new BaseCommandResponse
        {
            Id = blog.Id,
            Success = true,
        };
    }
}
