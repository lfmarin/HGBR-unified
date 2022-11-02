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
        public User GetUser(string userID) => _context.Users.FirstOrDefault(e => e.userName == userID);
        public void AddTokenToBlock(string token)
        {
            Console.WriteLine(token);
            TokenBlacklist TB = new TokenBlacklist();
            TB.strToken = token;
            _context.loggedOutTokens.Add(TB);
            _context.SaveChanges();
        }
        public bool ChangePassword(string usr, string newPass)
        {
            var user = _context.Users.Where(e => e.userName == usr).First();
            if( user.Password.Equals(newPass) )
                return false;
            
            Console.WriteLine("Contraseña de " + user.userName + " ha sido cambiada.");
            user.Password = newPass;
            _context.SaveChanges();
            return true;
        }
        public bool HasToken(string token)
        {
            return _context.loggedOutTokens.Select(e => e.strToken == token).First();
        }
    }
}

