using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace LearningPlatform.Application.DTO.BlogDTOs.Validators;
internal class UpdateBlogDtoValidator : AbstractValidator<UpdateBlogDTO>
{
    public UpdateBlogDtoValidator()
    {
        Include(new IBlogDtoValidator());
        RuleFor(x=>x.Title).NotEmpty().NotNull();
        RuleFor(x=>x.Text).NotEmpty().NotNull();
        RuleFor(x=>x.Writer_Id).NotEmpty().NotNull();
    }
}
