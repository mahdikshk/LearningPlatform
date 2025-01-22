using LearningPlatform.Application.DTO.BlogCommentDTOs;
using LearningPlatform.Application.DTO.BlogDTOs;
using LearningPlatform.Application.Features.Blog.Requests.Commands;
using LearningPlatform.Application.Features.Blog.Requests.Queries;
using LearningPlatform.Application.Features.BlogComment.Requests.Commands;
using LearningPlatform.Application.Features.BlogComment.Requests.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LearningPlatform.API.Controllers;

//[Authorize(Roles = "Writer,Admin")]
[Route("api/[controller]")]
[ApiController]
public class BlogsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<BlogsController> logger;
    public BlogsController(IMediator mediator, ILogger<BlogsController> logger)
    {
        _mediator = mediator;
        this.logger = logger;
    }

    [AllowAnonymous]
    [HttpGet("GetAll")]
    public async IAsyncEnumerable<BlogDTO> GetAll()
    {
        var request = new GetAllBlogsRequest();
        var stream = _mediator.CreateStream(request);
        await foreach (var dto in stream)
        {
            yield return dto;
        }
    }

    [AllowAnonymous]
    [HttpGet("GetWithDetails/{id:int}")]
    public async Task<IActionResult> GetByIdWithDetails([FromRoute]int id, CancellationToken cancellationToken)
    {
        var request = new GetBlogByIdWithDetailsRequest { Id = id };
        var response = await _mediator.Send(request, cancellationToken);
        if (response is null)
        {
            return NotFound();
        }
        return Ok(response);
    }

    [HttpDelete("Delete/{id:int}")]
    public async Task<IActionResult> Delete([FromRoute]int id, CancellationToken cancellationToken)
    {
        var request = new DeleteBlogRequest { DeleteBlogDto = new DeleteBlogDto { Id = id } };
        var response = await _mediator.Send(request, cancellationToken);
        if (!response.Success) return BadRequest(response);

        return Ok(response);
    }

    [HttpPut("Edit")]
    public async Task<IActionResult> Edit([FromBody] UpdateBlogDTO dto, CancellationToken cancellationToken)
    {
        var request = new UpdateBlogRequest
        {
            UpdateBlogDTO = dto
        };
        var result = await _mediator.Send(request, cancellationToken);
        if (!result.Success) return BadRequest(result);
        return Ok(result);
    }

    [HttpPost("Create")]
    public async Task<IActionResult> Create([FromBody] CreateBlogDTO dto, CancellationToken cancellationToken)
    {
        var request = new CreateBlogRequest()
        {
            BlogDTO = dto
        };
        var result = await _mediator.Send(request, cancellationToken);
        if (!result.Success) return BadRequest(result);
        return Ok();
    }

    [HttpPost("AddComment")]
    public async Task<IActionResult> AddComment(
        [FromBody] CreateBlogCommentDTO dto,
        CancellationToken cancellationToken)
    {
        var request = new CreateBlogCommentRequest()
        {
            CreateBlogCommentDTO = dto
        };
        var result = await _mediator.Send(request, cancellationToken);
        if (!result.Success) return BadRequest(result);
        return Ok(result);
    }

    [HttpPut("UpdateComment")]
    public async Task<IActionResult> UpdateComment([FromBody] UpdateBlogCommentDto dto, CancellationToken cancellationToken)
    {
        var request = new UpdateBlogCommentRequest
        {
            UpdateBlogCommentDto = dto
        };
        var result = await _mediator.Send(request, cancellationToken);
        if (!result.Success) return BadRequest(result);
        return Ok(result);
    }

    [HttpPut("DeleteComment")]
    public async Task<IActionResult> DeleteComment([FromBody] DeleteBlogCommentDto dto,CancellationToken cancellationToken)
    {
        var request = new DeleteBlogCommentRequest
        {
            DeleteBlogCommentDto = dto
        };
        var result = await _mediator.Send(request,cancellationToken);
        if (!result.Success) return BadRequest(result);
        return Ok(result);
    }

    [HttpGet("GetComments/{BlogId:int}")]
    public async IAsyncEnumerable<BlogCommentDTO> GetComments([FromRoute]int BlogId,CancellationToken cancellationToken)
    {
        var request = new GetAllBlogCommentsForBlogWithIdStreamingRequest
        {
            BlogId = BlogId
        };
        var stream = _mediator.CreateStream(request,cancellationToken);
        await foreach(var dto in stream)
        {
            yield return dto;
        }
    }
}