using System.ComponentModel.DataAnnotations;

namespace ddiscourse.Data;

public class Comment
{
    [Key]
    public int Id { get; set; }

    public int ArticleId { get; set; }
    public Article? Article { get; set; }

    public string AuthorId { get; set; } = string.Empty;
    public ApplicationUser? Author { get; set; }

    [Required, MaxLength(2000)]
    public string Body { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? EditedAt { get; set; }
}