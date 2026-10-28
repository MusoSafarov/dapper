using Dapper;
using Domain;
using Domain.Iterfrances;
using Infrastructure.DataBases;

namespace Infrastructure.Repositories;

public class BookRepositories : IBook
{
    public void AddBook(Book book)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"insert into book(title, publishedyear, totalcopies) values(@title, @publishedyear, @totalcopies)";
        conn.Execute(query,new{book.title,book.publishedyear,book.totalcopies});
        Console.WriteLine("Added!");
    }

    public void DeleteBook(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"delete from book where id = @id";
        conn.Execute(query,new{id});
        Console.WriteLine("Deleted!");
    }

    public int GetAmountByGenre(int genreId)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select Count(*) from book where genreid = @genreId";
        return conn.ExecuteScalar<int>(query,new{genreId});
    }

    public int GetAmountByPublishedYear(int year)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select Count(*) from book where publishedyeat = @year";
        return conn.ExecuteScalar<int>(query,new{year});   
    }


    public Book GetBook(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"select * from book where id = @id";
        var book = conn.QuerySingle<Book>(query,new{id});
        return book;    
    }

    public int GetBookAmount()
    {
        using var conn = Database.Connection();
        conn.Open();
        var  query = "select COUNT(*) from book";
        int cmd = conn.ExecuteScalar<int>(query);
        return cmd;
    }


    public List<Book> GetBookByAuthor(string authorname)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"select * from book join author on book.AuthorId=author.Id where author.fullname = @authorname";
        var book = conn.Query<Book>(query,new{authorname});
        return book.ToList();
    }

    public List<Book> GetBookByGenre(string genrename)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"select * from book join genre on book.GenreId=genre.Id where gener.name = @genrename";
        var book = conn.Query<Book>(query,new{genrename});
        return book.ToList();
    }


    public List<Book> GetBooks()
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = conn.Query<Book>($"select * from book");
        return query.ToList();
    }

    public void UpdateBook(Book book)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"update book set title = @title, publishedyear = @publishedyear, totalcopies = @totalcopies where id = @id";
        conn.Execute(query,book);
        System.Console.WriteLine("Updated!");
    }
}
