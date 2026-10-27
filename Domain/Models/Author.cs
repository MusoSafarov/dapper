namespace Domain.Models;

public class Author
{
    public int Id {get;set;}
    public string fullname {get;set;}=null!;
    public string country {get;set;}=null!;
    public int birthyear {get;set;}
}
