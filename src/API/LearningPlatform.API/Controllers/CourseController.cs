using System.Runtime.CompilerServices;
using LearningPlatform.Application.DTO.CourseDTOs;
using LearningPlatform.Application.Features.Course.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class CourseController : ControllerBase
{
    private readonly ILogger<CourseController> _logger;
    private readonly IMediator _mediator;
    public CourseController(ILogger<CourseController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }
    [HttpGet("GetAll")]
    public async IAsyncEnumerable<CourseDTO> GetAllCourses([EnumeratorCancellation]CancellationToken cancellationToken)
    {
        var request = new GetAllCoursesStreamingRequest();
        var stream = _mediator.CreateStream(request, cancellationToken);
        await foreach (var dto in stream)
        {
            yield return dto;
        }
    }
}
