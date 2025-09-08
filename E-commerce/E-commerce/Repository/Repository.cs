namespace E_commerce.Repository;

using Dapper;
using E_commerce.Repository.Interfaces;
using System.Data;
using System.Data.Odbc;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly string conectionstring = "Driver={ODBC Driver 18 for SQL Server};Server=server-terciario.hilet.com,14433;Database=Sol;Uid=sa;Pwd=MasterHilet2025;TrustServerCertificate=Yes;";

    public Repository() { }

    private IDbConnection CreateConnection()
    {
        return new OdbcConnection(conectionstring);
    }

    public async Task<IEnumerable<T>> GetAllAsync(string query)
    {
        using var connection = CreateConnection();
        return await connection.QueryAsync<T>(query);
    }

    public async Task<T?> GetByIdAsync(string query)
    {
        using var connection = CreateConnection();
        return await connection.QueryFirstOrDefaultAsync<T>(query);
    }


    public async Task<int> ExecuteAsync(string query)
    {
        using var connection = CreateConnection();
        return await connection.ExecuteAsync(query);
    }

}

