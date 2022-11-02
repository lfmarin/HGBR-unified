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
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(User))]
        public IActionResult LogOut()
        {
            var accessToken = Request.Headers[HeaderNames.Authorization];

            // Is the current account authorized?
            if (!String.IsNullOrEmpty(accessToken))
            {
                _usersService.AddLoggedOutToken(accessToken);
            }

            return Ok();
        }

        [HttpPost("hash")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        public IActionResult HashPass([FromBody] LoginInfo loginInfo)
        {
            Console.WriteLine(loginInfo.Password);
            var result = _usersService.getHash(loginInfo.Password);
            return Ok(result);
        }

        [HttpGet("user/all")]
        public IActionResult GetAllUser()
        {
            var result = _usersService.GetAll();
            return Ok(result);
        }

        [Authorize]
        [HttpPost]
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
    }
}

