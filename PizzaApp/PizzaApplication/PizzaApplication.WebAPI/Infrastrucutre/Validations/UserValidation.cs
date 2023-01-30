using FluentValidation;
using PizzaApplication.WebAPI.Infrastrucutre.Models;

namespace PizzaApplication.WebAPI.Infrastrucutre.Validations
{
    public class UserValidation : AbstractValidator<UserModel>
    {
        public UserValidation()
        {
            RuleFor((UserModel user) => user.FirstName)
                .NotEmpty().WithMessage("Firstname must not be empty")
                .Must((string FirstName) => FirstName.Length >= 2 && FirstName.Length <= 20)
                .WithMessage("Name Length must be greater than 2 and smaller than 20");


            RuleFor((UserModel user) => user.LastName)
                .NotEmpty().WithMessage("Lastnname must not be empty")
                .Must((string FirstName) => FirstName.Length >= 2 && FirstName.Length <= 30)
                .WithMessage("LastName Length must be greater than 2 and smaller than 30");

            RuleFor((user) => user.Email)
                .NotEmpty().EmailAddress();

            RuleFor((user) => user.PhoneNumber)
                .NotEmpty().WithMessage("Phone number should not be empty")
                .Must((int number) => number.ToString().Length == 9)
                .WithMessage("number length should be equal to 9");

            
        }
    }
}
