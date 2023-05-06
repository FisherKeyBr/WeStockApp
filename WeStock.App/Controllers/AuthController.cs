using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WeStock.App.Auth;
using WeStock.App.Dtos;
using WeStock.App.Exceptions;
using WeStock.Domain.Services;

namespace WeStock.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly UserService _userService;
        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Authenticate([FromBody] LoginDto loginDto)
        {
            var user = await _userService.GetBy(loginDto.Username, loginDto.Password);

            if(user is null)
            {
                throw new ProblemDetailsException("Username or password is incorrect!", 
                    HttpStatusCode.Unauthorized);
            }

            var token = TokenHelper.Generate(user);

            return Ok(new { token = token });
        }
    }
}
