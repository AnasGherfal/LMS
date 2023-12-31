﻿using Common.Wrappers;
using MediatR;

namespace Server.Features.Licenses.Unlock;

public sealed record UnlockLicenseCommand :IRequest<MessageResponse>
{
    public string? Id { get; set; }
}
