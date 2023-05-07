using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WeStock.Domain.Entities;
using WeStock.Domain.Repositories;

namespace WeStock.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : BaseController
    {
        private IValidator<User> _validator;
        private IUserRepository _userRepository;

        public UserController(IValidator<User> validator,
            IUserRepository userRepository)
        {
            _validator = validator;
            _userRepository = userRepository;
        }

        [HttpPost("newUser")]
        public async Task<CreatedResult> NewUser([FromBody] User user)
        {
            _validator.ValidateAndThrow(user);
            var newUser = await _userRepository.Add(user);

            //saving the password without crypt for now
            return Created(newUser.Id.ToString(), newUser);
        }
    }
}
