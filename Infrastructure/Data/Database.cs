using Npgsql;
namespace Infrastructure.DataBases;

public static class Database
{
    private static string connection = "Host=localhost;Port=5432;Database=practice;Username=postgres;Password=1234";
    public static NpgsqlConnection Connection()=> new NpgsqlConnection(connection);
}
