using FluentValidation;

namespace TaskManagement.Application.Features.Tasks.Commands.DeleteTask;

public sealed class DeleteTaskCommandValidator : AbstractValidator<DeleteTaskCommand>
{
    public DeleteTaskCommandValidator()
    {
        RuleFor(x => x.TaskId)
            .NotEmpty();
    }
}
