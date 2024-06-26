using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using LearningPlatform.Application.Contracts.Persistance;
using LearningPlatform.Application.DTO.Course;
using LearningPlatform.Application.Features.Course.Requests.Queries;
using MediatR;

namespace LearningPlatform.Application.Features.Course.Handlers.Queries;
internal class GetAllCoursesHandler : IRequestHandler<GetAllCoursesRequest, List<CourseDTO>>
{
    private readonly ICourseRepository _repository;
    private readonly IMapper _mapper;

    public GetAllCoursesHandler(ICourseRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<List<CourseDTO>> Handle(GetAllCoursesRequest request, CancellationToken cancellationToken)
    {
        var courses = await _repository.GetAllAsync(cancellationToken).ConfigureAwait(false);
        var dtos = _mapper.Map<List<CourseDTO>>(courses);
        return dtos;
    }
}
