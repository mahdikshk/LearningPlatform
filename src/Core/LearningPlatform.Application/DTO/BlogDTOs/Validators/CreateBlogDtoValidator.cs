using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace LearningPlatform.Application.DTO.BlogDTOs.Validators;
internal class CreateBlogDtoValidator : AbstractValidator<CreateBlogDTO>
{
    public CreateBlogDtoValidator()
    {
        RuleFor(x => x.Title).NotNull().NotEmpty().WithMessage("عنوان بلاگ نمیتواند خالی باشد");
        RuleFor(x=>x.Text).NotEmpty().NotNull().WithMessage("متن ورودی نمیتواند خالی باشد");
    }
}
