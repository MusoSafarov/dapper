using Domain.Models;

namespace Domain.Interfrances;

public interface IAuthor
{
    Task  Add(Author author);
    Task  Delete (int id);
    Task  Update (Author author);
    Task <Author> GetAuthor(int id);
    Task <List<Author>> GetAuthors();
    Task <int> GetAuthorAmount();
    Task <int> GetMinPublisheyearByAuthor(int id);
    Task <int> GetMaxPublisheyearByAuthor(int id);
}
