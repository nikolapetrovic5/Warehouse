using Warehouse.Service.Interfaces;

namespace Warehouse.Service;

public sealed class AuthenticationService : IAuthenticationService
{
    public Task<string> Authenticate(string username, string password)
    {
        throw new NotImplementedException();
    }
}
