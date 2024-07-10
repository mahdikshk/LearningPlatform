﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.DTO.CourseDTOs;
using LearningPlatform.Domain;
using MediatR;

namespace LearningPlatform.Application.Features.Course.Requests.Queries;
public class GetAllCoursesRequest : IRequest<List<CourseDTO>>
{
}
