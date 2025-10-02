using System;
using System.Collections.Generic;
using TaskManagement.Application.Features.Tasks.Queries;

namespace TaskManagement.Application.Features.Boards.Queries.GetBoardById;

public sealed record BoardDetailsDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public Guid ProjectId { get; init; }
    public int Order { get; init; }
    public IReadOnlyCollection<TaskDto> Tasks { get; init; } = Array.Empty<TaskDto>();
}
