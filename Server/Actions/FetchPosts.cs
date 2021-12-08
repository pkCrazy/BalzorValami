using System.Security.Cryptography;
using System.Text;
using BalzorValami.Server.Data;
using BalzorValami.Shared.Admin;
using Microsoft.EntityFrameworkCore;

namespace BalzorValami.Server.Actions;

internal class FetchPosts
{
    private readonly ApplicationDbContext _context;

    public FetchPosts(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<ExistingPost> Handle()
    {
        return _context.Posts
            .Include(post => post.Author)
            .Select(post => new ExistingPost
            {
                Id = post.Id,
                Title = post.Title,
                AuthorName = post.Author.UserName,
                Hash = GetHash(post.Author.UserName)
            })
            .ToArray();
    }

    private static string GetHash(string email)
    {
        var md5 = MD5.Create();

        byte[] hash = md5.ComputeHash(Encoding.Default.GetBytes(email.Trim()));

        StringBuilder builder = new();

        for (int i = 0; i < hash.Length; i++)
        {
            builder.Append(hash[i]);
        }

        return builder.ToString();
    }
}
