using System.Collections.Generic;
using ControlUsuarios.Models;

namespace ControlUsuarios.Services;

public interface IUsersService
{
    User? Authenticate(string username, string password);
    IEnumerable<User> GetAll();
    string getHash(string hash);
    bool AddLoggedOutToken(string token);
}
