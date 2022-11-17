using System.Collections.Generic;
using ControlUsuarios.Models;
using System.Linq;

namespace ControlUsuarios.Repositories
{
    public interface IUsersRepository
    {
        public IEnumerable<User> GetAll();
        public IQueryable<object> GetAllObject();
        public User GetUser(string UserID);
        public void AddTokenToBlock(string token);
        public bool HasToken(string token);

        public bool ChangePassword(string usr, string newPass);

        public bool AddUser(User usr);
        public IEnumerable<Role> GetRoles();
    }
}

