using System;
using System.Collections.Generic;

namespace TaskManagement.Application.Features.Projects.Queries.GetProjectById;

public sealed record ProjectDetailsDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
    public DateTime CreatedAtUtc { get; init; }
    public IReadOnlyCollection<BoardSummaryDto> Boards { get; init; } = Array.Empty<BoardSummaryDto>();
}

public sealed record BoardSummaryDto
{
    public Guid Id { get; init; }
    public string Name { get; init; } = string.Empty;
    public int Order { get; init; }
    public IReadOnlyCollection<TaskSummaryDto> Tasks { get; init; } = Array.Empty<TaskSummaryDto>();
}

public sealed record TaskSummaryDto
{
    public Guid Id { get; init; }
    public string Title { get; init; } = string.Empty;
    public string Status { get; init; } = string.Empty;
    public string Priority { get; init; } = string.Empty;
    public DateTime? DueDateUtc { get; init; }
}
