using FluentValidation;
using WeStock.Domain.Entities;
using WeStock.Domain.Repositories;

namespace WeStock.App.Validators
{
    public class UserValidator : AbstractValidator<User>
    {
        private IUserRepository _userRepository;

        public UserValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;

            RuleFor(user => user.UserName)
                .NotEmpty()
                .WithMessage("The username is required!");

            RuleFor(user => user.Password)
                .NotEmpty()
                .WithMessage("The password is required!");

            RuleFor(user => user.DisplayName)
                .NotEmpty()
                .WithMessage("The display name is required!");

            RuleFor(user => user)
                .Must(BeUniqueUserName)
                .WithMessage("The username already exists!");
        }

        private bool BeUniqueUserName(User user)
        {
            var task = _userRepository.GetByUsername(user.UserName);
            task.Wait();

            return task.Result is null;
        }
    }
}
