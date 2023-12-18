namespace Common.Services;

public interface IClientService
{
    public string IdentityId { get; }
    public string EmployeeNumber { get; }
    public string DisplayName { get; }
    public string Username { get; }
    public string[] Apps { get; }
}