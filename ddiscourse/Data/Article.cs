using System.ComponentModel.DataAnnotations;

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
}