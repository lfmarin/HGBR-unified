using System.Collections.Generic;
using ControlUsuarios.Models;

namespace ControlUsuarios.Repositories
{
    public interface IUsersRepository
    {
        public IEnumerable<User> GetAll();
    }
}

