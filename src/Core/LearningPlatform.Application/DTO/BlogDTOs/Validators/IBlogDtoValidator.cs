﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace LearningPlatform.Application.DTO.BlogDTOs.Validators;
internal class IBlogDtoValidator : AbstractValidator<IBlogDTO>
{
    public IBlogDtoValidator()
    {
        RuleFor(x=>x.Id).NotNull().NotEmpty().GreaterThan(0);
    }
}
