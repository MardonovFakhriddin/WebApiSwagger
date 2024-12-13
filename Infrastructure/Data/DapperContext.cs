namespace DefaultNamespace;
using Npgsql;

public class DapperContext
{
    private readonly string _connectionString =
        "Host=localhost;Port=5432;Database=RentaCar;User Id=postgres;Password=LMard1909";

    public NpgsqlConnection Connection()
    {
        return new NpgsqlConnection(_connectionString);
    }
}