using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.DTO.CourseDTOs;
using MediatR;

namespace LearningPlatform.Application.Features.Course.Requests.Queries;
public class GetAllCoursesWithDetailsRequest : IRequest<IEnumerable<CourseDTO>>
{
}
