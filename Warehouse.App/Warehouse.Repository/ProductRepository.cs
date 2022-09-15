using Warehouse.Entity;
using Warehouse.Repository.Interfaces;
using Dapper;
using Warehouse.Repository.Factories.Interfaces;

namespace Warehouse.Repository;

public sealed class ProductRepository : IProductRepository
{
    private readonly IConnectionFactory _connectionFactory;

    public ProductRepository(IConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<bool> AddAsync(Product entity)
    {
        var query = @"
                      INSERT INTO Product (
                        Code, Price, Note,
                        Quantity, Currency, 
                        ArrivalDate, IngestionDate
                      ) 
                      VALUES 
                        (
                            @Code, @Price, @Note,
                            @Quantity, @Currency, 
                            @ArrivalDate, @IngestionDate
                        );
";
        using var connection = _connectionFactory.Create();

        var rowsAffected = await connection.ExecuteAsync(query, 
            new 
            {
                entity.Code,
                entity.Price,
                entity.Note,
                entity.Quantity,
                entity.Currency,
                entity.ArrivalDate,
                entity.IngestionDate
            });
        return rowsAffected == 1;
    }

    public async Task<Product> GetAsync(Guid id)
    {
        var query = "SELECT * FROM Product WHERE Id = @Id;";
        using var connection = _connectionFactory.Create();

        return await connection.QuerySingleOrDefaultAsync<Product>(query, new { Id = id.ToString() });
    }

    public async Task<IEnumerable<Product>> GetAllAsync()
    {
        var query = "SELECT * FROM Product;";
        using var connection = _connectionFactory.Create();

        var products = await connection.QueryAsync<Product>(query);
        if(products == null)
            return Enumerable.Empty<Product>();

        return products;
    }

    public async Task<bool> RemoveAsync(Guid id)
    {
        var query = @"DELETE FROM Product WHERE Id = @Id;";
        using var connection = _connectionFactory.Create();

        var rowsAffected = await connection.ExecuteAsync(query, new { Id = id.ToString() });
        return rowsAffected == 1;
    }

    public async Task<bool> UpdateAsync(Product entity)
    {
        var query = @"
                      UPDATE 
                        Product 
                      SET 
                        Code = @Code, 
                        Price = @Price, 
                        Note = @Note, 
                        Quantity = @Quantity, 
                        Currency = @Currency, 
                        ArrivalDate = @ArrivalDate
                      WHERE Id = @ Id;
";
        using var connection = _connectionFactory.Create();

        var rowsAffected = await connection.ExecuteAsync(query, entity);
        return rowsAffected == 1;
    }
}
