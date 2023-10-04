using System.Data;
using FluentValidation;

namespace CleanArch.Application.Products.Command.Create;

public sealed class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Sku).NotEmpty();
        RuleFor(x => x.Currency).NotEmpty();
        RuleFor(x => x.Amount).NotEmpty();
    }
}