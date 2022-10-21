using System;
namespace ControlUsuarios.Repositories
{
    public interface IRolesRepository
    {
        public IEnumerable<Models.Role> GetAll();
    }
}

