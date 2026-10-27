using System.Runtime.CompilerServices;
using Domain;
using Domain.Models;
using Infrastructure.Repositories;

var now1 = new AuthorRepositories();
var now = new BookRepositories();
var mma = new GenreRepository();

while (true)
{
    Console.WriteLine("==============================");
    Console.WriteLine(@"    1.Show all authors.
    2.Show author by id.
    3.Add author.
    4.Delete author.
    5.Update author.
    6.Show all books.
    7.Show book by id.
    8.Add books.
    9.Delete books.
    10.Update books.
    11.Show all genres.
    12.Show genre by id.
    13.Add genres.
    14.Delete genres.
    15.Update genres.
    16.GetBookByAythor.
    17.GetBookByGenre.
    0. Exits");
    var a = Console.ReadLine();
    Console.WriteLine("==============================");
    switch (a)
    {
        case "1":
        var authors = now1.GetAuthors();
        foreach (var item in authors)
        {
            System.Console.WriteLine($"{item.Id} {item.fullname} {item.country} {item.birthyear}");
        }
        break;
        case "2":
        Console.Write("Enter id: ");
        var d = Convert.ToInt32(Console.ReadLine());
        var get = now1.GetAuthor(d);
        System.Console.WriteLine($"{get.Id} {get.fullname} {get.country} {get.birthyear}");
        break;
        case "3":
        Console.Write("Enter fullname: ");
        var t = Console.ReadLine();
        Console.Write("Enter country: ");
        var p = Console.ReadLine();
        Console.Write("Enter birthyear: ");
        var tc = Convert.ToInt32(Console.ReadLine());
        var m = new Author()
        {
            fullname = t,
            country = p,
            birthyear = tc
        };
        now1.Add(m);
        break;
        case "4":
        Console.Write("Enetr id for delete: ");
        var id = Convert.ToInt32(Console.ReadLine());
        now1.Delete(id);
        break;
        case "5":
        Console.Write("Enetr id for update: ");
        var h = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter fullname for update: ");
        var tt = Console.ReadLine();
        Console.Write("Enter country for update: ");
        var pp = Console.ReadLine();
        Console.Write("Enter birthyear for update: ");
        var tcc = Convert.ToInt32(Console.ReadLine());
        var o = new Author()
        {
            Id = h,
            fullname = tt,
            country = pp,
            birthyear = tcc
        };
        now1.Update(o);
        break;

        case "6":
        var books = now.GetBooks();
        foreach (var item in books)
        {
            System.Console.WriteLine($"{item.Id} {item.title} {item.publishedyear} {item.totalcopies} {item.AuthorId} {item.GenreId}");
        }
        break;
        case "7":
        Console.Write("Enter id: ");
        var dd = Convert.ToInt32(Console.ReadLine());
        var gett = now.GetBook(dd);
        System.Console.WriteLine($"{gett.Id} {gett.title} {gett.publishedyear} {gett.totalcopies} {gett.AuthorId} {gett.GenreId}");
        break;
        case "8":
        Console.Write("Enter title: ");
        var th = Console.ReadLine();
        Console.Write("Enter publishedyear: ");
        var pr = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter totalcopies: ");
        var tccc = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter authorId: ");
        var thg = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter genreId: ");
        var thf = Convert.ToInt32(Console.ReadLine());
        var l = new Book()
        {
            title = th,
            publishedyear = pr,
            totalcopies = tccc,
            AuthorId = thg,
            GenreId = thf
        };
        now.AddBook(l);
        break;
        case "9":
        Console.Write("Enetr id for delete: ");
        var idd = Convert.ToInt32(Console.ReadLine());
        now.DeleteBook(idd);
        break;
        case "10":
        Console.Write("Enetr id for update: ");
        var hl = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter title for update: ");
        var ttf = Console.ReadLine();
        Console.Write("Enter publishedyear for update: ");
        var pps = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter totalcopies for update: ");
        var tccd = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter authorId for update: ");
        var ttfg = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter genreId for update: ");
        var ttfn = Convert.ToInt32(Console.ReadLine());
        var f = new Book()
        {
            Id = hl,
            title = ttf,
            publishedyear = pps,
            totalcopies = tccd,
            AuthorId = ttfg,
            GenreId = ttfn
        };
        now.UpdateBook(f);
        break;

         case "11":
        var genres = mma.GetGenres();
        foreach (var item in genres)
        {
            System.Console.WriteLine($"{item.Id} {item.Name}");
        }
        break;
        case "12":
        Console.Write("Enter id: ");
        var dj = Convert.ToInt32(Console.ReadLine());
        var getk = mma.GetGenre(dj);
        System.Console.WriteLine($"{getk.Id} {getk.Name}");
        break;
        case "13":
        Console.Write("Enter name: ");
        var ta = Console.ReadLine();
        var mdd = new Genre()
        {
            Name = ta
        };
        mma.AddGenre(mdd);
        break;
        case "14":
        Console.Write("Enetr id for delete: ");
        var idf= Convert.ToInt32(Console.ReadLine());
        mma.DeleteGenre(idf);
        break;
        case "15":
        Console.Write("Enetr id for update: ");
        var hi = Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter name for update: ");
        var tb = Console.ReadLine();
        var ol = new Genre()
        {
            Id = hi,
            Name = tb
        };
        mma.UpdateGenre(ol);
        break;

        case "16":
        Console.Write("Enter author name: ");
        var rr = Console.ReadLine();
        var bookss = now.GetBookByAuthor(rr);
        foreach (var item in bookss)
        {
            System.Console.WriteLine($"{item.Id} {item.title} {item.publishedyear} {item.totalcopies} {item.AuthorId} {item.GenreId}");
        }
        break;

        case "17":
        Console.Write("Enter genre name: ");
        var rrr = Console.ReadLine();
        var booksss = now.GetBookByGenre(rrr);
        foreach (var item in booksss)
        {
            System.Console.WriteLine($"{item.Id} {item.title} {item.publishedyear} {item.totalcopies} {item.AuthorId} {item.GenreId}");
        }
        break;

        case "0":
        System.Console.WriteLine("Exiting ....");
        return;
    }

}