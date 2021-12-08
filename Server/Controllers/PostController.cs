using BalzorValami.Server.Actions;
using BalzorValami.Server.Attributes;
using BalzorValami.Server.Data;
using BalzorValami.Shared.Admin;
using Microsoft.AspNetCore.Mvc;

namespace BalzorValami.Server.Controllers;

[ApiController]
[ApiRoute("admin")]
public class PostController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PostController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IEnumerable<ExistingPost> Index() => new FetchPosts(_context).Handle();

    [HttpPost]
    public void Store(Post post) => new StorePost(_context).Handle(post);

    [HttpGet]
    public IEnumerable<User> Edit() => _context
        .Users
        .Select(u => new User
        {
            Id = u.Id,
            Name = u.UserName
        })
        .ToArray();
}
