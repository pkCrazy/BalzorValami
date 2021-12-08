using Microsoft.AspNetCore.Identity;

namespace BalzorValami.Server.Models;

public class ApplicationUser : IdentityUser
{
    public ICollection<Post> Posts { get; set; }

    public ApplicationUser() => Posts = new List<Post>();
}
