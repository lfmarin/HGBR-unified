using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ControlUsuarios.Models;
using ControlUsuarios.Services;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Net.Http.Headers;

namespace UsersManagement.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly IUsersService _usersService;

        public UsersController(ILogger<UsersController> logger, IUsersService usersService)
        {
            _logger = logger;
            _usersService = usersService;
        }

        [HttpPost("authenticate")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public IActionResult Authenticate([FromBody] LoginInfo loginInfo)
        {
            var result = _usersService.Authenticate(loginInfo.Username, loginInfo.Password);

            if (result == null)
                return Unauthorized();

            return Ok(result);
        }

        [HttpPost("logout")]
        [Authorize]
        public IActionResult LogOut()
        {
            var accessToken = Request.Headers[HeaderNames.Authorization];

            // Is the current account authorized?
            if (!String.IsNullOrEmpty(accessToken))
            {
                _usersService.AddLoggedOutToken(accessToken);
                return Ok();
            }

            return Unauthorized();
        }

        [HttpGet("all")]
        [Authorize(Roles = "Admin,Coordinador")]
        public IActionResult GetAllUser()
        {
            var result = _usersService.GetAllObject();
            return Ok(result);
        }

        [HttpPost("adduser")]
        [Authorize(Roles = "Admin")]
        public IActionResult AddUser([FromBody] User usr)
        {
            var result = _usersService.AddUser(usr);
            return Ok(result);
        }

        [HttpGet("getroles")]
        [Authorize(Roles = "Admin,Coordinador")]
        public IActionResult GetRolesList()
        {
            var result = _usersService.GetRoles();
            return Ok(result);
        }
        /**
            Obtiene la información del usuario actual.
        */
        [HttpGet("details")]
        public IActionResult GetUser()
        {
            var m = User.Claims.FirstOrDefault(c => c.Type == "UserName").Value;
            var user = _usersService.GetUser(m);
            //var result = _usersService.GetUser(userID);
            return Ok(user);
        }

        [HttpPost("cambiarpass")]
        [Authorize]
        public IActionResult ChangePassword([FromBody] newPassData data)
        {
            var m = User.Claims.FirstOrDefault(c => c.Type == "UserName").Value;
            var user = _usersService.GetUser(m);
            var ProcessDone = _usersService.ChangePassword(user.userName, data.givenPassword, data.newPassword);
            return ProcessDone ? Ok() : Unauthorized();
        }

        [Authorize]
        [HttpPost("setrole")]
        [Authorize(Roles = "Admin,Coordinador")]
        public IActionResult SetRole([FromQuery] int empNo, [FromQuery] string role)
        {
            var userIdentity = new IdentityUser
            {
                UserName = "Daenerys Targaryen",
                Email = "danytargaryen@iceandfire.org",
                EmailConfirmed = true
            };

            return Ok();
        }

        public class newPassData {
            public string givenPassword {get; set;}
            public string newPassword {get; set;}
        }
    }
}

