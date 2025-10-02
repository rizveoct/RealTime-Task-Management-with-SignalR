using MediatR;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.Boards.Queries.GetBoardsByProjectId;
using TaskManagement.Application.Features.Projects.Queries.GetProjectById;

namespace TaskManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ProjectsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProjectsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{projectId:guid}")]
    [ProducesResponseType(typeof(ProjectDetailsDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid projectId, CancellationToken cancellationToken)
    {
        var project = await _mediator.Send(new GetProjectByIdQuery(projectId), cancellationToken);
        if (project is null)
        {
            return NotFound();
        }

        return Ok(project);
    }

    [HttpGet("{projectId:guid}/boards")]
    [ProducesResponseType(typeof(IReadOnlyCollection<BoardDetailsDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetBoards(Guid projectId, CancellationToken cancellationToken)
    {
        var boards = await _mediator.Send(new GetBoardsByProjectIdQuery(projectId), cancellationToken);
        return Ok(boards);
    }
}
