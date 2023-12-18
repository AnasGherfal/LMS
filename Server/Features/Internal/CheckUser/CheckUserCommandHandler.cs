using Common.Constants;
using Common.Entities;
using Common.Events.Category;
using Common.Events.User;
using Common.Exceptions;
using Common.Services;
using Common.Services.Dtos;
using Common.Wrappers;
using Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Server.Features.Internal.CheckUser;

public sealed record CheckUserCommandHandler : IRequestHandler<CheckUserCommand, SystemPermissions>
{
    private readonly AppDbContext _dbContext;

    public CheckUserCommandHandler(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<SystemPermissions> Handle(CheckUserCommand request, CancellationToken cancellationToken)
    {
        //TODO: Add Caching for fetch.
        var user = _dbContext.Users
            .Select(p => new {p.IdentityId, p.Permissions})
            .FirstOrDefault(p => p.IdentityId == request.IdentityId);
        if (user != null) return user.Permissions;
        var @event = new UserCreatedEvent(request.IdentityId, Guid.NewGuid(), new UserCreatedEventData()
        {
            IdentityId = request.IdentityId,
            EmployeeNumber = request.EmployeeNumber,
            DisplayName = request.DisplayName,
            Username = request.Username,
            Permissions = SystemPermissions.None,
        });
        var data = new User();
        data.Apply(@event);
        await _dbContext.Users.AddAsync(data, cancellationToken);
        await _dbContext.Events.AddAsync(@event, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return data.Permissions;
    }
}
