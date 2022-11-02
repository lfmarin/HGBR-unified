using System;
using System.Collections.Generic;
using System.Linq;
using ControlUsuarios.Models;
namespace ControlUsuarios.Repositories.Impl
{
    public class UsersRepository : IUsersRepository
    {
        private readonly userContext _context;
        public UsersRepository(userContext context) => _context = context;
        public IEnumerable<User> GetAll() => _context.Users.ToList();
        public void AddTokenToBlock(string token)
        {
            Console.WriteLine(token);
            TokenBlacklist TB = new TokenBlacklist();
            TB.strToken = token;
            _context.loggedOutTokens.Add(TB);
            _context.SaveChanges();
        }
        public bool HasToken(string token)
        {
            return _context.loggedOutTokens.Select(e => e.strToken == token).First();
        }
    }
}

