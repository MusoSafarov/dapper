using Domain.Models;

namespace Domain.Interfrances;

public interface IGenre
{
    void AddGenre(Genre genre);
    void DeleteGenre (int id);
    void UpdateGenre (Genre genre);
    Genre GetGenre(int id);
    List<Genre> GetGenres();
}
