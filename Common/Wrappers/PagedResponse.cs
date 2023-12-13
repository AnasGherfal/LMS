namespace Common.Wrappers;

public class PagedResponse<T> : MessageResponse
{
    public int TotalPages { get; private set; }
    public List<T> Content { get; private set; }

    public PagedResponse(string message, IEnumerable<T>? items, int totalPages)
    {
        Msg = message;
        Content = new List<T>(items ?? Array.Empty<T>());
        TotalPages = totalPages;
    }
}