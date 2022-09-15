using Warehouse.Entity;
using Warehouse.Repository.Interfaces;
using Dapper;
using Warehouse.Repository.Factories.Interfaces;

namespace Warehouse.Repository;

public sealed class AccountRepository : IAccountRepository
{
    private readonly IConnectionFactory _connectionFactory;

    public AccountRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<bool> AddAsync(Account entity)
    {
        var query = @"
                      INSERT INTO Account (
                        Username, Pin,
                        Email, IngestionDate
                      ) 
                      VALUES 
                        (
                            @Username, @Pin,
                            @Email, @IngestionDate
                        );
";
        using var connection = _connectionFactory.Create();

        var rowsAffected = await connection.ExecuteAsync(query,
            new
            {
                entity.Username,
                entity.Pin,
                entity.Email,
                entity.IngestionDate
            });
        return rowsAffected == 1;
    }

    public async Task<Account> GetAsync(Guid id)
    {
        var query = "SELECT * FROM Account WHERE Id = @Id;";
        using var connection = _connectionFactory.Create();

        return await connection.QuerySingleOrDefaultAsync<Account>(query, new { Id = id.ToString() });
    }

    public async Task<IEnumerable<Account>> GetAllAsync()
    {
        var query = "SELECT * FROM Account;";
        using var connection = _connectionFactory.Create();

        var accounts = await connection.QueryAsync<Account>(query);
        if(accounts == null)
            return Enumerable.Empty<Account>();

        return accounts;
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        var query = @"DELETE FROM Account WHERE Id = @Id;";
        using var connection = _connectionFactory.Create();

        var rowsAffected = await connection.ExecuteAsync(query, new { Id = id.ToString() });
        return rowsAffected == 1;
    }

    public async Task<bool> UpdateAsync(Account entity)
    {
        var query = @"
                      UPDATE 
                        Account 
                      SET 
                        Username = @Username, 
                        Pin = @Pin, 
                        Email = @Email
                      WHERE Id = @Id;
";
        using var connection = _connectionFactory.Create();

        var rowsAffected = await connection.ExecuteAsync(query, entity);
        return rowsAffected == 1;
    }
}
