using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ddiscourse.Data;

public class Board
{
    [Key]
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;  // optional description of the board

    public List<Article> Articles { get; set; } = [];  // a list of articles associated with this board

    public async Task<Board?> GetBoard(ApplicationDbContext Db, int Id)
    {
        Board? board = await Db.Boards.AsNoTracking().FirstOrDefaultAsync(b => b.Id == Id);
        return board;
    }
}