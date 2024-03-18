namespace Blazor_Blog.Models
{
    public record struct LoggedInUser(int UserId, string DisplayName)
    {
        public readonly bool IsEmpty => UserId == 0;        
    }
}
