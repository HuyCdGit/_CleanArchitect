using CleanArch.Application.Menus.Command.Create;
using FluentValidation;

namespace CleanArch.Application.Menus.Command;

public class CreateMenuCommandValidator : AbstractValidator<CreateMenuCommand>
{
    public CreateMenuCommandValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
        RuleFor(x => x.MenuSections).NotEmpty();
    }
}