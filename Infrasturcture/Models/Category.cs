using Common;
using Common.Constants;
using Infrastructure.Models.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;
using Common.Events.Category;

namespace Infrastructure.Models;

public class Category : Entity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public GeneralStatus Status { get; set; }
    public string? Description { get; set; }
    public string FileLink { get; set; } = string.Empty;


    public void Apply(CategoryCreatedEvent @event)
    {
        Sequence= @event.Sequence;
        Name=@event.Data.Name;
        Id = @event.AggregateId;
        Description= @event.Data.Description;
        Status = GeneralStatus.Active;
        CreatedOn = @event.DateTime;
        UpdatedOn = @event.DateTime;
        FileLink = @event.Data.Icon.FileLink;
    }
    public void Apply(CategoryUpdatedEvent @event)
    {
        Sequence = @event.Sequence;
        Name=@event.Data.Name;
        Description= @event.Data.Description;
        Status = GeneralStatus.Active;
        UpdatedOn = @event.DateTime;
        

    }

    public void Apply(CategoryLockedEvent @event)
    {
        Sequence = @event.Sequence;
        UpdatedOn = @event.DateTime;
        Status = GeneralStatus.Locked;
    }

    public void Apply(CategoryUnlockedEvent @event)
    {
        Sequence = @event.Sequence;
        UpdatedOn = @event.DateTime;
        Status = GeneralStatus.Active;
    }

    public void Apply(CategoryDeletedEvent @event)
    {
        Sequence = @event.Sequence;
        UpdatedOn = @event.DateTime;
        IsDeleted = true;
    }

    public void Apply(CategoryIconUpdatedEvent @event)
    {
        Sequence = @event.Sequence;
        UpdatedOn = @event.DateTime;
        FileLink = @event.Data.FileLink;
    }
}
