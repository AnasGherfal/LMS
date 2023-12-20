namespace Common.Options;

public class PersistenceOption
{
    public const string Section = "Persistence";
    public string ConnectionString { get; set; } = string.Empty;
    public string ConnectionString2 { get; set; } = string.Empty;
}