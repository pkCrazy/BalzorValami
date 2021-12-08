using BalzorValami.Server.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BalzorValami.Server.Data.Configurations;

internal class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.Property(p => p.AuthorId).IsRequired();
        builder.HasOne(p => p.Author)
            .WithMany((ApplicationUser author) => author.Posts)
            .HasForeignKey(p => p.AuthorId);
    }
}