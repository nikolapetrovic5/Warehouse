namespace Warehouse.Service.Interfaces;

public interface IAuthenticationService
{
    Task<string> Authenticate(string username, string password);
}
