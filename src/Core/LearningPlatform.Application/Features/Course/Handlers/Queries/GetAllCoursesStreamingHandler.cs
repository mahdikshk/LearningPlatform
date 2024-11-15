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
internal class GetAllCoursesStreamingHandler : IStreamRequestHandler<GetAllCoursesStreamingRequest, CourseDTO>
{
    private readonly ICourseRepository _courseRepository;
    private readonly IMapper _mapper;

    public GetAllCoursesStreamingHandler(ICourseRepository courseRepository, IMapper mapper)
    {
        _courseRepository = courseRepository;
        _mapper = mapper;
    }

    public async IAsyncEnumerable<CourseDTO> Handle(GetAllCoursesStreamingRequest request, CancellationToken cancellationToken)
    {
        await foreach(var course in _courseRepository.GetAllWithDetailsStreaming(cancellationToken))
        {
            if(cancellationToken.IsCancellationRequested)
            {
                yield break;
            }
            var dto = _mapper.Map<CourseDTO>(course);
            yield return dto;
        }
    }
}
