using Domain.Models;

namespace Domain.Interfrances;

public interface IGenre
{
    Task  AddGenre(Genre genre);
    Task  DeleteGenre (int id);
    Task  UpdateGenre (Genre genre);
    Task <Genre> GetGenre(int id);
    Task <List<Genre>> GetGenres();
    Task <int> GetGenreAmount();
    Task <int> GetMinPublisheyearByGenre(int id);
    Task <int> GetMaxPublisheyearByGenre(int id);
}
