﻿using API._1.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API._1.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if(username == "usuario" && password == "123456")
            {
                var token = TokenService.GenerateToken(new Domain.Models.UsuarioAggregate.Usuario());
                return Ok(token);
            }
            return BadRequest("Username or Password Invalid");
        }
    }
}
