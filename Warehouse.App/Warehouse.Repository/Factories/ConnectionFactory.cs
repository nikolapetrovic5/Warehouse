using Warehouse.Repository.Factories.Interfaces;
using System.Data.SqlClient;

namespace Warehouse.Repository.Factories;

public sealed class ConnectionFactory : IConnectionFactory
{
    public SqlConnection Create()
    {
        return new SqlConnection("Server=DESKTOP-O3H3HP8;Database=Warehouse;User id=User3;password=user3;");
    }
}
