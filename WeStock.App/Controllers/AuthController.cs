using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using WeStock.App.Auth;
using WeStock.App.Dtos;
using WeStock.App.Exceptions;
using WeStock.Domain.Entities;
using WeStock.Domain.Services;

namespace WeStock.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private IValidator<LoginDto> _validator;
        private readonly UserService _userService;
        public AuthController(UserService userService,
            IValidator<LoginDto> validator)
        {
            _userService = userService;
            _validator = validator;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Authenticate([FromBody] LoginDto loginDto)
        {
            _validator.ValidateAndThrow(loginDto);
            var user = await _userService.GetBy(loginDto.Username, loginDto.Password);

            if (user is null)
            {
                throw new ProblemDetailsException("Username or password is incorrect!",
                    HttpStatusCode.Unauthorized);
            }

            var token = TokenHelper.Generate(new UserClaims { 
                Id = user.Id, 
                DisplayName = user.DisplayName, 
                UserName = user.UserName 
            });

            return Ok(new { token = token });
        }
    }
}
