using Dapper;
using Domain;
using Domain.Iterfrances;
using Infrastructure.DataBases;

namespace Infrastructure.Repositories;

public class BookRepositories : IBook
{
    public async Task  AddBook(Book book)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"insert into book(title, publishedyear, totalcopies) values(@title, @publishedyear, @totalcopies)";
         await conn.ExecuteAsync(query,book);
        Console.WriteLine("Added!");
    }

    public async Task  DeleteBook(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"delete from book where id = @id";
         await conn.ExecuteAsync(query,new{id});
        Console.WriteLine("Deleted!");
    }

    public async Task < int> GetAmountByGenre(int genreId)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select Count(*) from book where genreid = @genreId";
        return await conn.ExecuteScalarAsync<int>(query,new{genreId});
    }

    public async Task <int> GetAmountByPublishedYear(int year)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = "select Count(*) from book where publishedyeat = @year";
        return await conn.ExecuteScalarAsync<int>(query,new{year});   
    }


    public async Task  <Book> GetBook(int id)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"select * from book where id = @id";
        var book = await conn.QuerySingleAsync<Book>(query,new{id});
        return book;    
    }

    public async Task  <int> GetBookAmount()
    {
        using var conn = Database.Connection();
        conn.Open();
        var  query = "select COUNT(*) from book";
        int cmd = await conn.ExecuteScalarAsync<int>(query);
        return cmd;
    }


    public async Task  <List<Book>> GetBookByAuthor(string authorname)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"select * from book join author on book.AuthorId=author.Id where author.fullname = @authorname";
        var book = await  conn.QueryAsync<Book>(query,new{authorname});
        return book.ToList();
    }

    public async Task  <List<Book>> GetBookByGenre(string genrename)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"select * from book join genre on book.GenreId=genre.Id where gener.name = @genrename";
        var book = await conn.QueryAsync<Book>(query,new{genrename});
        return book.ToList();
    }


    public async  Task<List<Book>> GetBooks()
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = await conn.QueryAsync<Book>($"select * from book");
        return query.ToList();
    }

    public async Task  UpdateBook(Book book)
    {
        using var conn = Database.Connection();
        conn.Open();
        var query = $"update book set title = @title, publishedyear = @publishedyear, totalcopies = @totalcopies where id = @id";
        await conn.ExecuteAsync(query,book);
        System.Console.WriteLine("Updated!");
    }
}
