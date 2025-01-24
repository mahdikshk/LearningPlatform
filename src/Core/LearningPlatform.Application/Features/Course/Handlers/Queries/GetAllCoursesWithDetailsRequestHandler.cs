using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Application.DTO.CourseDTOs;
using LearningPlatform.Application.Features.Course.Requests.Queries;
using MediatR;

namespace LearningPlatform.Application.Features.Course.Handlers.Queries;
internal class GetAllCoursesWithDetailsRequestHandler : IRequestHandler<GetAllCoursesWithDetailsRequest, IEnumerable<CourseDTO>>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public GetAllCoursesWithDetailsRequestHandler(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CourseDTO>> Handle(GetAllCoursesWithDetailsRequest request, CancellationToken cancellationToken)
    {
        var courses = await _courseRepository.GetAllCoursesWithDetail(cancellationToken);
        var dtos = new List<CourseDTO>();
        foreach (var course in courses)
        {

        }
        return [];
    }
}
