using System;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ControlUsuarios.Repositories;
using ControlUsuarios.Models;
using Microsoft.EntityFrameworkCore;

namespace ControlUsuarios.Services.Impl
{
    public class UserService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IRolesRepository _rolesRepository;
        private readonly JwtSettings _jwtSettings;
        private readonly userContext _context;

        public UserService(userContext usersRepository) //, IRolesRepository rolesRepository)
        {
            _context = usersRepository;
            //_rolesRepository = rolesRepository;
            //_jwtSettings = options.Value;
        }

        public User Authenticate(string username, string password)
        {
            var users = _usersRepository.GetAll();
            var user = users.SingleOrDefault(u => u.userName == username && u.Password== password);
            if (user == null) return user;

            var roles = _rolesRepository.GetAll();
            var role = roles.First(r => r.Id == user.IdRole);

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = System.Text.Encoding.ASCII.GetBytes(_jwtSettings.Secret);

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new Claim("UserName", user.userName),
                        //new Claim("DisplayName", $"{user.FirstName} {user.LastName}"),
                        //new Claim("CanRead", user.Canread.Value.ToString()),
                        //new Claim("CanWrite", user.Canwrite.Value.ToString()),
                        new Claim(ClaimTypes.Role, role.Name)
                    }
                ),
                Expires = DateTime.Now.AddHours(1),
                NotBefore = DateTime.Now,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            return user;
        }

        public IQueryable<object> GetAll()
        {
            try
            {
                return _context.Users.Select(p => new {
                    ID = p.ID,
                    UserName = p.userName,
                    IdRole = p.IdRole
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}

