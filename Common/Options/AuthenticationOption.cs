namespace Common.Options;

public class AuthenticationOption
{
    public const string Section = "Identity";
    public string Secret { get; set; } = null!;
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public int TokenExpiration { get; set; }
}