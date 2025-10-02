using AutoMapper;
using System.Collections.Generic;
using TaskManagement.Application.Features.Boards.Queries.GetBoardById;
using TaskManagement.Application.Features.Projects.Queries.GetProjectById;
using TaskManagement.Application.Features.Tasks.Queries;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Mapping;

public sealed class ProjectProfile : Profile
{
    public ProjectProfile()
    {
        CreateMap<TaskItem, TaskSummaryDto>()
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status.ToString()))
            .ForMember(dest => dest.Priority, opt => opt.MapFrom(src => src.Priority.ToString()));

        CreateMap<Board, BoardSummaryDto>()
            .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks ?? new List<TaskItem>()));

        CreateMap<Project, ProjectDetailsDto>()
            .ForMember(dest => dest.Boards, opt => opt.MapFrom(src => src.Boards ?? new List<Board>()));

        CreateMap<Board, BoardDetailsDto>()
            .ForMember(dest => dest.Tasks, opt => opt.MapFrom(src => src.Tasks ?? new List<TaskItem>()));
    }
}
