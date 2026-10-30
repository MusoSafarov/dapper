using Dapper;
using Domain.Interfrances;
using Domain.Models;
using Infrastructure.DataBases;
using Npgsql;

namespace Infrastructure.Repositories;

public class GenreRepository : IGenre
{
    public async Task  AddGenre(Genre genre)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"insert into genre(name) values(@name)";
        await conn.ExecuteAsync(query, new{genre.Name});
        Console.WriteLine("Added!");
    }

    public async Task  DeleteGenre(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"delete from genre where id = @id";
        await conn.ExecuteAsync (query,new{id});
        Console.WriteLine("Deleted!");
    }

    public async Task  <Genre> GetGenre(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"select * from genre where id = @id";
        var genre = await conn.QuerySingleAsync<Genre>(query,new{id});
        return genre;
    }

    public async Task  <List<Genre>> GetGenres()
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = await conn.QueryAsync<Genre>($"select * from genre");
        return query.ToList();
    }

    public async  Task  UpdateGenre(Genre genre)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"update genre set name = @name where id = @id";
        await conn.ExecuteAsync(query,genre);
        System.Console.WriteLine("Updated!");
    }
    public async Task < int> GetGenreAmount()
    {
        using var conn = Database.Connection();
        conn.Open();
        var  query = "select COUNT(*) from genre";
        int cmd = await conn.ExecuteScalarAsync <int>(query);
        return cmd;
    }

    public async Task < int> GetMinPublisheyearByGenre(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select min(publishedyear) from book where genreid = @id";
        return await  conn.ExecuteScalarAsync <int>(query,new{id}); 
    }

    public async Task  <int> GetMaxPublisheyearByGenre(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select max(publishedyear) from book where genreid = @id";
        return await  conn.ExecuteScalarAsync <int>(query,new{id}); 
    }
}
