namespace Domain.Iterfrances;

public interface IBook
{
    Task AddBook(Book book);
    Task UpdateBook(Book book);
    Task DeleteBook(int id);
    Task <Book> GetBook(int id);
    Task <List<Book>> GetBooks();
    Task <List<Book>> GetBookByAuthor(string authorname);
    Task <List<Book>> GetBookByGenre(string genrename);
    Task <int> GetBookAmount();
    Task <int> GetAmountByPublishedYear(int year);
    Task <int> GetAmountByGenre(int genreId);
}
