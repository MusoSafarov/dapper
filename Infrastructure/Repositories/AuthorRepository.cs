using Dapper;
using Domain;
using Domain.Interfrances;
using Domain.Models;
using Infrastructure.DataBases;
using Npgsql;

namespace Infrastructure.Repositories;

public class AuthorRepositories : IAuthor
{
    public async Task Add(Author author)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"insert into author(fullname,country,birthyear) values(@fullname, @country, @birthyear)";
        await conn.ExecuteAsync(query,author);
        Console.WriteLine("Added!");
    }

    public async Task Delete(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"delete from author where id = @id";
        await conn.ExecuteAsync(query,new{id});
        Console.WriteLine("Deleted!");
    }

    public async Task  <Author> GetAuthor(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"select * from author where id = @id";
        var author = await conn.QuerySingleAsync<Author>(query,new{id});
        return author;
    }

    public async Task  <List<Author>> GetAuthors()
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = await conn.QueryAsync<Author>($"select * from author");
        return query.ToList();
    }

    public async Task  Update(Author author)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"update author set fullname = @fullname, country = @country, birthyear = @birthyear where id = @Id";
         await conn.ExecuteAsync(query,author);
        System.Console.WriteLine("Updated!");
    }
    public async Task  <int> GetAuthorAmount()
    {
        using var conn = Database.Connection();
        conn.Open();
        var  query = "select COUNT(*) from author";
        int cmd = await conn.ExecuteScalarAsync<int>(query);
        return cmd;
    }

    public async Task  <int> GetMinPublisheyearByAuthor(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select min(publishedyear) from book where authorid = @id";
        return await conn.ExecuteScalarAsync<int>(query,new{id});  
    }

    public async Task  <int> GetMaxPublisheyearByAuthor(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select max(publishedyear) from book where authorid = @id";
        return await conn.ExecuteScalarAsync<int>(query,new{id});  
    }
}
