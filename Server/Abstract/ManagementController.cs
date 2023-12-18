using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Server.Abstract;

[Route("v1.0/management/[controller]")]
public abstract class ManagementController : ControllerBase
{
    private IMediator? _mediator;
    protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;
}