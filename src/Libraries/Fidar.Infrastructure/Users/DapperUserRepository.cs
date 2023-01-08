using Dapper;
using Fidar.Domain.Users;
using Fidar.Infrastructure.Users.Contracts;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace Fidar.Infrastructure.Users;

public class DapperUserRepository : UserRepository
{
    private readonly IConfiguration configuration;
    public DapperUserRepository(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public async Task<int> AddAsync(User entity)
    {
        entity.AddTime(DateTime.Now);
        var sql = "Insert into Users (Name,Age,CreateOn,Credit) VALUES (@Name,@Age,@CreateOn,@Credit)";
        using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }


    public async Task<int> DeleteAsync(int id)
    {
        var sql = "DELETE FROM Users WHERE Id = @Id";
        using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, new { Id = id });
            return result;
        }
    }

    public async Task<IReadOnlyList<User>> GetAllAsync()
    {
        var sql = "SELECT * FROM Users";
        using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        {
            connection.Open();
            var result = await connection.QueryAsync<User>(sql);
            return result.ToList();
        }
    }

    public async Task<User> GetByIdAsync(int id)
    {
        var sql = "SELECT * FROM Users WHERE Id = @Id";
        using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        {
            connection.Open();
            var result = await connection.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
            return result;
        }
    }

    public async Task<int> UpdateAsync(User entity)
    {
        var sql = "UPDATE Users SET Name = @Name, Age = @Age, CreateOn = @CreateOn, Credit = @Credit   WHERE Id = @Id";
        using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
        {
            connection.Open();
            var result = await connection.ExecuteAsync(sql, entity);
            return result;
        }
    }
}
