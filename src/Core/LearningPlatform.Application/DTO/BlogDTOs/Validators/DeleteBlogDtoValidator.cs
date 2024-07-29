using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace LearningPlatform.Application.DTO.BlogDTOs.Validators;
internal class DeleteBlogDtoValidator : AbstractValidator<DeleteBlogDto>
{
    public DeleteBlogDtoValidator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
    }
}
