using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JWTCoreDemo.Models;
using JWTCoreDemo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTCoreDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _authenticateService;
        public AuthenticationController(IAuthenticationService authenticateService)
        {
            _authenticateService = authenticateService;
        }
        [HttpPost]
        public IActionResult Post([FromBody] User model)
        {
            var user = _authenticateService.Authenticate(model.UserName, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or Password is Incorrect" });
            return Ok(user);

        }
    }
}