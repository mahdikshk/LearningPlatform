﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.DTO.BlogCommentDTOs;
using LearningPlatform.Domain;

namespace LearningPlatform.Application.DTO.BlogDTOs;
public abstract class IBlogDTO
{
    public int Id { get; set; }
}