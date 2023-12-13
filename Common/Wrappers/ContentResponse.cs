namespace Common.Wrappers;

public class ContentResponse<T> : MessageResponse
{
    public T Content { get; set; }
    
    public ContentResponse(string message, T content)
    {
        Msg = message;
        Content = content;
    }
}