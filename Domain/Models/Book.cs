
namespace Domain;

public class Book
{
    public int Id { get; set; }
    public string title { get; set; } = null!;
    public int publishedyear { get; set; }
    public int totalcopies { get; set; }
    public int AuthorId { get; set; }
    public int GenreId { get; set; }
}
