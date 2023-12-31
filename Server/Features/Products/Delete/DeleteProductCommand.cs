﻿using Common.Wrappers;
using MediatR;

namespace Server.Features.Products.Delete;

public sealed record DeleteProductCommand: IRequest<MessageResponse>
{
    public string? Id { get; set; }
}
