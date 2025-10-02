using FluentValidation;
using MediatR;

namespace TaskManagement.Application.Behaviors;

public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)


    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)

        => _validators = validators;

    // v11 signature: (request, cancellationToken, next)
    public async Task<TResponse> Handle(
        TRequest request,
        CancellationToken cancellationToken,
        RequestHandlerDelegate<TResponse> next)

    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);

            var validationResults = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(context, cancellationToken)));
            var failures = validationResults.SelectMany(result => result.Errors).Where(error => error is not null).ToList();

            if (failures.Count != 0)
            {
                throw new ValidationException(failures);
            }

            var results = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken))
            );

            var failures = results
                .SelectMany(r => r.Errors)
                .Where(e => e is not null)
                .ToList();

            if (failures.Count != 0)
                throw new ValidationException(failures);

        }

        return await next();
    }
}
