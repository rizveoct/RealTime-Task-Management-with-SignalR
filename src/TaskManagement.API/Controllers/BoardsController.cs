using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.Features.Boards.Queries.GetBoardById;

namespace TaskManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BoardsController : ControllerBase
{
    private readonly IMediator _mediator;

    public BoardsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{boardId:guid}")]
    [ProducesResponseType(typeof(BoardDetailsDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetById(Guid boardId, CancellationToken cancellationToken)
    {
        var board = await _mediator.Send(new GetBoardByIdQuery(boardId), cancellationToken);
        if (board is null)
        {
            return NotFound();
        }

        return Ok(board);
    }
}
