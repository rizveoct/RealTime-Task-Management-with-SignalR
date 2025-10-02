using AutoMapper;
using MediatR;
using TaskManagement.Application.Abstractions.Persistence;

namespace TaskManagement.Application.Features.Projects.Queries.GetProjectById;

public sealed class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, ProjectDetailsDto?>
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public GetProjectByIdQueryHandler(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<ProjectDetailsDto?> Handle(GetProjectByIdQuery request, CancellationToken cancellationToken)
    {
        var project = await _projectRepository.GetByIdAsync(request.ProjectId, cancellationToken);
        return project is null ? null : _mapper.Map<ProjectDetailsDto>(project);
    }
}
