using CleanArch.Domain.Common.Models.Interfaces;

namespace CleanArch.Domain.Menu.Envents;

public record MenuCreated(Menu Menu) : IDomainEvent;