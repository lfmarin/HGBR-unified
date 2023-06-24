using System;
using System.Collections.Generic;

namespace ControlUsuarios.Repositories
{
    public interface IRolesRepository
    {
        public IEnumerable<Models.Role> GetAll();
    }
}

