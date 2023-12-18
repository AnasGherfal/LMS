using Common.Wrappers;
using MediatR;

namespace Server.Features.Licenses.FetchAll;
public sealed record FetchLicensesQueryResponse : IRequest<PagedResponse<FetchLicensesQueryResponse>>
{
    public Guid Id { get; set; }
    public string Icon { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedOn { get; set; }
}
