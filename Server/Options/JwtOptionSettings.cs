namespace Server.Options;

public class JwtOptionSettings
{
    public const string SectionName = "JwtOptionSettings";
    public string Secret { get; set; } = default!;
    public string Issuer { get; set; } = default!;
    public string Audience { get; set; } = default!;
    public int TokenExpiration { get; set; }
}