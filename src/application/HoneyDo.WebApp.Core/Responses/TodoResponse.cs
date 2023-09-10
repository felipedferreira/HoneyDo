namespace HoneyDo.WebApp.Core.Responses;

public record TodoResponse(string Title, string Description, Guid Id)
{
    public TodoResponse(string title, string description) : this(title, description, Guid.NewGuid())
    {
    }
};