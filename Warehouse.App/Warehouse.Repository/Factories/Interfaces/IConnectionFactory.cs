using Warehouse.Repository.Factories.Abstractions;
using System.Data.SqlClient;

namespace Warehouse.Repository.Factories.Interfaces;

public interface IConnectionFactory : IFactory<SqlConnection>
{
}
