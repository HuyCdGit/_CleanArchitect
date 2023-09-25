using CleanArch.Domain.Menu.Envents;
using MediatR;

namespace CleanArch.Application.Common.Events;

public class DummyHanlder : INotificationHandler<MenuCreated>
{
    public Task Handle(MenuCreated notification, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}