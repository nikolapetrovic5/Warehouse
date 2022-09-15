namespace Warehouse.Repository.Factories.Abstractions;

public interface IFactory<T>
{
    T Create();
}
