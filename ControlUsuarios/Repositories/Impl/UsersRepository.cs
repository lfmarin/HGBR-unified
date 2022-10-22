using System;
using ControlUsuarios.Models;
namespace ControlUsuarios.Repositories.Impl
{
    public class UsersRepository : IUsersRepository
    {
        private readonly userContext _context;
        public UsersRepository(userContext context) => _context = context;
        public IEnumerable<User> GetAll() => _context.Users.ToList();
    }
}

