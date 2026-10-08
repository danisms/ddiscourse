using System.ComponentModel.DataAnnotations;
using AngleSharp.Dom;
using Microsoft.EntityFrameworkCore;

namespace ddiscourse.Data;

public class Article
{
    [Key]
    public int Id { get; set; }

    public int BoardId { get; set; }  // foreign key to the Board entity
    public Board? Board { get; set; }  // navigation property to the Board entity

    public string AuthorId { get; set; } = string.Empty;  // foreign key to the ApplicationUser entity
    public ApplicationUser? Author { get; set; }  // navigation property to the ApplicationUser entity

    [Required, MaxLength(120)]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Body { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? EditedAt { get; set; }  // set on edit; use to show "edited" when this filled is null

    public List<Comment> Comments { get; set; } = [];
    public List<Rating> Ratings { get; set; } = [];

    public async Task<Article?> GetArticle(ApplicationDbContext Db, int Id)
    {
        Article? article = await Db.Articles.AsNoTracking()
        .Include(a => a.Board)
        .Include(a => a.Author)
        .Include(a => a.Comments.OrderBy(c => c.CreatedAt))
        .ThenInclude(c => c.Author)
        .Include(a => a.Ratings)
        .AsSplitQuery()
        .FirstOrDefaultAsync(article => article.Id == Id);

        return article;
    }

    public async Task<List<Article>?> GetAllArticles(ApplicationDbContext Db, int BoardId)
    {
        List<Article>? articles = await Db.Articles.AsNoTracking()
        .Include(a => a.Board)
        .Include(a => a.Author)
        .Include(a => a.Comments)
        .Include(a => a.Ratings)
        .AsSplitQuery()
        .ToListAsync();

        articles?.RemoveAll(a => a.BoardId != BoardId);

        return articles;
    }
}