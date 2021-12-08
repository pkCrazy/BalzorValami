using BalzorValami.Server.Data;
using BalzorValami.Shared;
using Microsoft.EntityFrameworkCore;

namespace BalzorValami.Server.Actions;

internal class GetPost
{
    private readonly ApplicationDbContext _context;

    public GetPost(ApplicationDbContext context)
    {
        _context = context;
    }

    public ConcretePost Handle(int id)
    {
        return _context.Posts
            .Include(p => p.Author)
            .Where(p => p.Id == id)
            .Select(p => new ConcretePost
            {
                AuthorName = p.Author.UserName,
                Body = p.Body,
                Title = p.Title
            })
            .First();
    }
}
