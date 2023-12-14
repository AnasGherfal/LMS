using Common;
using Common.Constants;
using Core.Events.Category;
using Infrastructure.Events.Category;
using Infrastructure.Models.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net;

namespace Infrastructure.Models;

public class Category : Entity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public GeneralStatus Status { get; set; }
    public string? Description { get; set; }
    public DocumentForCategory Icon { get; set; } = default!;


    public void Apply(CategoryCreatedEvent @event)
    {
        Sequence= @event.Sequence;
        Name=@event.Data.Name;
        Id = @event.AggregateId;
        Description= @event.Data.Description;
        Status = GeneralStatus.Active;
        CreatedOn = @event.DateTime;
        UpdatedOn = @event.DateTime;
        Icon = new DocumentForCategory()
        {
            Id = @event.Data.Icon.FileIdentifier,
            CategoryId = @event.AggregateId,
            FileLink = @event.Data.Icon.FileLink,
            IconType = @event.Data.Icon.IconType,
            IsActive = true,
            CreatedOn = @event.DateTime
        };
     
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
        if (@event.Data.OldFileIdentifier != null)
        {
            if (Icon.Id == @event.Data.OldFileIdentifier)
                Icon.IsActive = false;
           
        }
        Icon =new DocumentForCategory()
        {
            CategoryId = @event.AggregateId,
            Id = @event.Data.FileIdentifier,
            FileLink = @event.Data.FileLink,
            IconType = @event.Data.IconType,
            IsActive = true,
            CreatedOn = @event.DateTime,
        };
    }
}
