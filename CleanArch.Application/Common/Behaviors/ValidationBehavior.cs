using ErrorOr;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace CleanArch.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> :
    IPipelineBehavior<TRequest, TResponse>
    where TRequest : notnull
{
    private readonly IValidator<TRequest>? _validator;

    public ValidationBehavior(IValidator<TRequest>? validator = null)
    {
        _validator = validator;
    }

    public async Task<TResponse> Handle(
        TRequest request
        , RequestHandlerDelegate<TResponse> next
        , CancellationToken cancellationToken)
    {
        if(_validator is null)
        {
            return await next();
        }

        var validationResult = await _validator.ValidateAsync(request, cancellationToken); 
        if(validationResult.IsValid)
        {
            return await next();
        }

        var errors = validationResult.Errors.
        ConvertAll(ValidationFailure => Error.Validation(
            ValidationFailure.PropertyName,
            ValidationFailure.ErrorMessage
        ));

        return (dynamic)errors;
    }

    //public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
   // {
        // if (_validator.Any())
        // {
        //     var context = new ValidationContext<TRequest>(request);

        //     var validationResults = await Task.WhenAll(
        //         _validator.Select(v =>
        //             v.ValidateAsync(context, cancellationToken)));

        //     var failures = validationResults
        //         .Where(r => r.Errors.Any())
        //         .SelectMany(r => r.Errors)
        //         .ToList();

        //     if (failures.Any())
        //         throw new ValidationException(failures);
        // }
        // return await next();

        // var context = new ValidationContext<TRequest>(request);

        // var failures = _validator
        //         .Select(v => v.Validate(context))
        //         .SelectMany(result => result.Errors)
        //         .Where(f => f != null)
        //         .ToList();

        //     if (failures.Count != 0)
        //     {
        //         throw new ValidationException(failures);
        //     }

        // return await next();
    //}
}
