using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Identity.WebApi.Models;
using Identity.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Identity.WebApi.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Authenticate([FromBody] Login loginParam)
        {
            var token = _userService.Authenticate(loginParam.Username, loginParam.Password);

            if (!token)
                return BadRequest(new { message = "Username or Password is incorrect" });

            return Ok(token);
        }
    }
}