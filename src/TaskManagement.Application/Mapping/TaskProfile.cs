using AutoMapper;
using TaskManagement.Application.Features.Tasks.Queries;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Mapping;

public sealed class TaskProfile : Profile
{
    public TaskProfile()
    {
        CreateMap<TaskItem, TaskDto>();
    }
}
