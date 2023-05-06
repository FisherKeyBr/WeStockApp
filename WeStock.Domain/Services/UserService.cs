using FluentValidation;
using WeStock.Domain.Entities;
using WeStock.Domain.Repositories;

namespace WeStock.Domain.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetBy(string userName, string password)
        {
            return await _userRepository.GetBy(userName, password);
        }
    }
}
