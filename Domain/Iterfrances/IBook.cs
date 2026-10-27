namespace Domain.Iterfrances;

public interface IBook
{
    void AddBook(Book book);
    void UpdateBook(Book book);
    void DeleteBook(int id);
    Book GetBook(int id);
    List<Book> GetBooks();
    List<Book> GetBookByAuthor(string authorname);
    List<Book> GetBookByGenre(string genrename);
}
