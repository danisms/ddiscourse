using System.ComponentModel.DataAnnotations;

namespace ddiscourse.Data;

public class Rating
{
    [Key]
    public int Id { get; set; }

    public int ArticleId { get; set; }
    public Article? Article { get; set; }

    public string UserId { get; set; } = string.Empty;
    public ApplicationUser? User { get; set; }

    [Range(1, 5)]
    public int Value { get; set; }
}