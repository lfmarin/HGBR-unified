﻿using System;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using ControlUsuarios.Repositories;
using ControlUsuarios.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ControlUsuarios.Services.Impl
{
    public class UserService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IRolesRepository _rolesRepository;
        private readonly JwtSettings _jwtSettings;

        public UserService(IOptions<JwtSettings> options, IUsersRepository usersRepository, IRolesRepository rolesRepository) //, IRolesRepository rolesRepository)
        {
            _usersRepository = usersRepository;
            _rolesRepository = rolesRepository;
            _jwtSettings = options.Value;
        }

        public User? Authenticate(string username, string password)
        {
            IEnumerable<User> users = GetAll().AsEnumerable();
            var user = users.SingleOrDefault<User>(u => u.userName == username && u.Password == password);

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

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.Password = String.Empty;

            return user;
        }

        public IEnumerable<User> GetAll()
        {
            try
            {
                var users = _usersRepository.GetAll();
                return users.Select(p => {
                    return p;
                });
            }
            catch (System.Exception)
            {
                throw;
            }
        }
    }
}

