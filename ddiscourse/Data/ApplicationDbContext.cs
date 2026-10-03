using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ddiscourse.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<Board> Boards => Set<Board>();
    public DbSet<Article> Articles => Set<Article>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<Rating> Ratings => Set<Rating>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);  // required: because Identity's tables are configured here

        // Make Board names unique.
        builder.Entity<Board>().HasIndex(x => x.Name).IsUnique();

        // Restrict delete of board while it still has articles
        builder.Entity<Article>().HasOne(a => a.Board).WithMany(x => x.Articles).HasForeignKey(a => a.BoardId).OnDelete(DeleteBehavior.Restrict);

        // Restrict rating to one rating per user per article
        builder.Entity<Rating>().HasIndex(r => new { r.ArticleId, r.UserId }).IsUnique();
    }
}
