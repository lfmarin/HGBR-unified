using ControlUsuarios.Models;

namespace ControlUsuarios.Services;

public interface IUsersService
{
    User Authenticate(string username, string password);
    IQueryable<object> GetAll();
}
