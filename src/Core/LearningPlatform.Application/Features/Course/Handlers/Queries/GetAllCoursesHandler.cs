using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LearningPlatform.Application.DTO.Course;
using LearningPlatform.Application.Features.Course.Requests.Queries;
using Mediator;

namespace LearningPlatform.Application.Features.Course.Handlers.Queries;
internal class GetAllCoursesHandler : IRequestHandler<GetAllCoursesRequest, List<CourseDTO>>
{
    public ValueTask<List<CourseDTO>> Handle(GetAllCoursesRequest request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
