// using CleanArch.Application.Products.Command.Update;
// using FluentValidation;

// namespace CleanArch.Application.Products.Command.Delete;

// public sealed class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
// {
//     public UpdateProductCommandValidator()
//     {
//         RuleFor(x => x.Id).NotEmpty();
//         RuleFor(x => x.Name).NotEmpty();
//         RuleFor(x => x.Sku).NotEmpty();
//         RuleFor(x => x.Currency).NotEmpty();
//         RuleFor(x => x.Amount).NotEmpty();
//     }
// }