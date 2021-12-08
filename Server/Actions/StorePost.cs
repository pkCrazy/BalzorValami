using BalzorValami.Server.Data;
using BalzorValami.Shared.Admin;

namespace BalzorValami.Server.Actions;

internal class StorePost
{
    private readonly ApplicationDbContext _context;

    public StorePost(ApplicationDbContext context)
    {
        _context = context;
    }

    public void Handle(Post post)
    {
        var author = _context.Users.First(u => u.Id == post.AuthorId);

        Models.Post newPost = new()
        {
            Title = post.Title,
            Body = post.Body,
            Author = author
        };

        _context.Posts.Add(newPost);
        _context.SaveChanges();
    }
}
