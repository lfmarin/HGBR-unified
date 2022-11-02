using System.Collections.Generic;
using ControlUsuarios.Models;

namespace ControlUsuarios.Repositories
{
    public interface IUsersRepository
    {
        public IEnumerable<User> GetAll();
        public User GetUser(string UserID);
        public void AddTokenToBlock(string token);
        public bool HasToken(string token);

        public bool ChangePassword(string usr, string newPass);
    }
}

