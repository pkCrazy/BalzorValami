namespace BalzorValami.Server.Models;

public class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }

    public string AuthorId { get; init; }
    public ApplicationUser Author { get; init; }

    public Post()
    {
        Title = string.Empty;
        Body  = string.Empty;
        AuthorId = string.Empty;
        Author = new();
    }
}
