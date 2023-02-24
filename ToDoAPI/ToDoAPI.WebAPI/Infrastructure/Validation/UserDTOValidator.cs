using FluentValidation;
using ToDoAPI.WebAPI.Infrastructure.Models;


namespace ToDoAPI.WebAPI.Infrastructure.Validation
{
    public class UserDTOValidator : AbstractValidator<UserDTO>
    {
        public UserDTOValidator()
        {
            RuleFor((UserDTO d) => d.Password)
                .Must((string password) =>
                {
                    return !string.IsNullOrEmpty(password) && password.Length > 8;
                }).WithMessage("password length must be more than 8");

            RuleFor((UserDTO d) => d.UserName)
                .Must((string userName) =>
                {
                    return !string.IsNullOrEmpty(userName) && userName.Length <= 50;
                }).WithMessage("UserName length must be less or equal to 50");
        }
    }
}
