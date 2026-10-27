using Dapper;
using Domain;
using Domain.Interfrances;
using Domain.Models;
using Infrastructure.DataBases;
using Npgsql;

namespace Infrastructure.Repositories;

public class AuthorRepositories : IAuthor
{
    public void Add(Author author)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"insert into author(fullname,country,birthyear) values(@fullname, @country, @birthyear)";
        conn.Execute(query,new{author.fullname,author.country,author.birthyear});
        Console.WriteLine("Added!");
    }

    public void Delete(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"delete from author where id = @id";
        conn.Execute(query,new{id});
        Console.WriteLine("Deleted!");
    }

    public Author GetAuthor(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"select * from author where id = @id";
        var author = conn.QuerySingle<Author>(query,new{id});
        return author;
    }

    public List<Author> GetAuthors()
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = conn.Query<Author>($"select * from author");
        return query.ToList();
    }

    public void Update(Author author)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"update author set fullname = @fullname, country = @country, birthyear = @birthyear where id = @Id";
        conn.Execute(query,author);
        System.Console.WriteLine("Updated!");
    }

}
