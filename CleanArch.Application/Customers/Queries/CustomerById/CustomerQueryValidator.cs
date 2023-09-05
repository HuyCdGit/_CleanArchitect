using CleanArch.Application.Products.Queries;
using FluentValidation;

namespace CleanArch.Application.Customers.Command.CustomerById;

public sealed class CustomerQueryValidator : AbstractValidator<ProductQuery>
{
    public CustomerQueryValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
    }
}