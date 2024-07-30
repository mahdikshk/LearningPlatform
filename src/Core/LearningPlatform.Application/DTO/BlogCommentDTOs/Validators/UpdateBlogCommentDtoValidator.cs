using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace LearningPlatform.Application.DTO.BlogCommentDTOs.Validators;
internal class UpdateBlogCommentDtoValidator : AbstractValidator<UpdateBlogCommentDto>
{
    public UpdateBlogCommentDtoValidator()
    {
        
    }
}
