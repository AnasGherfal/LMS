namespace Server.Features.LookUps;

public sealed record FetchLookUpsQueryResponse
{
    public short Id { get; set; } = default!;
    public string Name { get; set; } = string.Empty;
}
