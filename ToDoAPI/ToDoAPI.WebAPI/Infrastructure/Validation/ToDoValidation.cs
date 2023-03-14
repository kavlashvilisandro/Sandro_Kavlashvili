using FluentValidation;
using ToDoAPI.WebAPI.Infrastructure.Models;


namespace ToDoAPI.WebAPI.Infrastructure.Validation
{
    public class ToDoValidation : AbstractValidator<ToDoRegisterDTO>
    {
        public ToDoValidation()
        {
            RuleFor((ToDoRegisterDTO x) => x.Title)
                .NotEmpty().WithMessage("Should not be empty")
                .MaximumLength(100).WithMessage("max Length is 100");
        }
    }
}
