using BalzorValami.Server.Actions;
using BalzorValami.Server.Attributes;
using BalzorValami.Server.Data;
using BalzorValami.Shared;
using BalzorValami.Shared.Admin;
using Microsoft.AspNetCore.Mvc;

namespace BalzorValami.Server.Controllers;

[ApiController]
[ApiRoute]
public class PostFrontendController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public PostFrontendController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<ExistingPost> Index() => new FetchPosts(_context).Handle();

    [HttpGet("{id}")]
    public ConcretePost Show(int id) => new GetPost(_context).Handle(id);
}
