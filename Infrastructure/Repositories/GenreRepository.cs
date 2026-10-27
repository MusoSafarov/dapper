using Dapper;
using Domain.Interfrances;
using Domain.Models;
using Infrastructure.DataBases;
using Npgsql;

namespace Infrastructure.Repositories;

public class GenreRepository : IGenre
{
    public void AddGenre(Genre genre)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"insert into genre(name) values(@name)";
        conn.Execute(query, new{genre.Name});
        Console.WriteLine("Added!");
    }

    public void DeleteGenre(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"delete from genre where id = @id";
        conn.Execute(query,new{id});
        Console.WriteLine("Deleted!");
    }

    public Genre GetGenre(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"select * from genre where id = @id";
        var genre = conn.QuerySingle<Genre>(query,new{id});
        return genre;
    }

    public List<Genre> GetGenres()
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = conn.Query<Genre>($"select * from genre");
        return query.ToList();
    }

    public void UpdateGenre(Genre genre)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"update genre set name = @name where id = @id";
        conn.Execute(query,genre);
        System.Console.WriteLine("Updated!");
    }

}
