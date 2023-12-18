using Common.Constants;
using Common.Entities;
using Common.Events.License;
using Common.Events.Product;
using Common.Services;
using Common.Wrappers;
using Infrastructure;
using MediatR;

namespace Server.Features.Licenses.Create;

public sealed record CreateLicenseCommandHandler(IClientService _client, AppDbContext _dbContext) : IRequestHandler<CreateLicenseCommand, MessageResponse>
{
    private readonly IClientService _client = _client;
    private readonly AppDbContext _dbContext =_dbContext;
    public async Task<MessageResponse> Handle(CreateLicenseCommand request, CancellationToken cancellationToken)
    {
        var @event = new LicenseCreatedEvent(_client.IdentityId, Guid.NewGuid(), new LicenseCreatedEventData()
        {
            DepartmentId = Guid.Parse(request.DepartmentId!),
            ProductId = Guid.Parse(request.ProductId!),
            SerialKey = request.SerialKey!,
            ImpactLevel = request.ImpactLevel!.Value,
            ImpactDescription = request.ImpactDescription!,
           Contact= request.Contact!,
           StartDate = DateTime.Parse(request.StartDate!),
            ExpireDate = DateTime.Parse(request.ExpireDate!),
            PriceInUSD = request.PriceInUSD!.Value,
            PriceInLYD = request.PriceInLYD!.Value,
            NumOfDevices=request.NumOfDevices!,
            TimeType = request.TimeType!.Value,
        });
        var data = new License();
        data.Apply(@event);
        await _dbContext.Licenses.AddAsync(data, cancellationToken);
        await _dbContext.Events.AddAsync(@event, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return new MessageResponse()
        {
            Msg = nameof(Locale.LicenseCreated)
        };

    }
}
