using Domain.Models;

namespace Domain.Interfrances;

public interface IAuthor
{
    void Add(Author author);
    void Delete (int id);
    void Update (Author author);
    Author GetAuthor(int id);
    List<Author> GetAuthors();
    int GetAuthorAmount();
    int GetMinPublisheyearByAuthor(int id);
    int GetMaxPublisheyearByAuthor(int id);
}
