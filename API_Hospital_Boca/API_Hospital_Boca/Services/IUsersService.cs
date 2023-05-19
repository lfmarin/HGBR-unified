using System.Collections.Generic;
using ControlUsuarios.Models;
using System.Linq;

namespace ControlUsuarios.Services;

public interface IUsersService
{
    User Authenticate(string username, string password);
    IEnumerable<User> GetAll();
    IQueryable<object> GetAllObject();
    User GetUser(string userID);
    string getHash(string hash);
    bool AddLoggedOutToken(string token);
    bool ChangePassword(string usr, string givenPassword, string newPassword);
    bool AddUser(User usr);
	IEnumerable<Role> GetRoles();
}
