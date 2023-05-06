using FluentValidation;
using WeStock.App.Dtos;

namespace WeStock.App.Validators
{
    public class LoginValidator : AbstractValidator<LoginDto>
    {
        public LoginValidator()
        {
            RuleFor(dto => dto.Username)
                .NotEmpty()
                .WithMessage("The username field is required!");

            RuleFor(dto => dto.Password)
                .NotEmpty()
                .WithMessage("The password field is required!");
        }
    }
}
