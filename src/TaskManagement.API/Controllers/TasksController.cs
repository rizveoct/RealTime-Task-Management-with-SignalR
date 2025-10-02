using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.Tasks.Commands.CreateTask;
using TaskManagement.Application.Features.Tasks.Queries;
using TaskManagement.Application.Features.Tasks.Queries.GetTaskById;

namespace TaskManagement.API.Controllers;

[ApiController]
[Route("api/v1/tasks")]
[Authorize]
public sealed class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<TaskDto>> CreateTask([FromBody] CreateTaskCommand command, CancellationToken cancellationToken)
    {
        var task = await _mediator.Send(command, cancellationToken);
        return CreatedAtAction(nameof(GetTaskById), new { taskId = task.Id }, task);
    }

    [HttpGet("{taskId:guid}")]
    [ProducesResponseType(typeof(TaskDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TaskDto>> GetTaskById(Guid taskId, CancellationToken cancellationToken)
    {
        var task = await _mediator.Send(new GetTaskByIdQuery(taskId), cancellationToken);
        if (task is null)
        {
            return NotFound();
        }

        return Ok(task);
    }
}
