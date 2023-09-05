using CleanArch.Application.Products.Command.Update;
using CleanArch.Application.Products.Queries;
using FluentValidation;

namespace CleanArch.Application.Products.Command.Delete;

public sealed class UpdateProductQueryValidator : AbstractValidator<ProductQuery>
{
    public UpdateProductQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}