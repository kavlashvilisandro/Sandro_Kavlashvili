using FluentValidation;
using EventsItAcademyGe.WebAPI.Infrastructure.Models;

namespace EventsItAcademyGe.WebAPI.Infrastructure.Validations
{
    public class UserLoginRegistrationDTOValidation : AbstractValidator<UserLoginRegistrationDTO>
    {
        public UserLoginRegistrationDTOValidation()
        {
            RuleFor((UserLoginRegistrationDTO model) => model.userName)
                .Must(userName => userName.Length > 5 && userName.Length < 20)
                .WithMessage("username length should be more than 5 and less then 20");

            RuleFor((UserLoginRegistrationDTO model) => model.password)
                .Must(password => password.Length > 8)
                .WithMessage("password length should be more than 8");
        }
    }
}
