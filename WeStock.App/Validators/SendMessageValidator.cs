using FluentValidation;
using WeStock.App.Dtos;

namespace WeStock.App.Validators
{
    public class SendMessageValidator : AbstractValidator<SendMessageDto>
    {
        public SendMessageValidator()
        {
            RuleFor(dto => dto.Message)
                .NotEmpty()
                .WithMessage("The message field is required!");
        }
    }
}
