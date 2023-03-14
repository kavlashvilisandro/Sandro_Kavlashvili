using FluentValidation;
using PizzaApplication.WebAPI.Infrastrucutre.Models;


namespace PizzaApplication.WebAPI.Infrastrucutre.Validations
{
    public class PizzaValidation : AbstractValidator<PizzaModel>
    {
        public PizzaValidation()
        {
            RuleFor((PizzaModel pizza) => pizza.Name)
                .NotEmpty().WithMessage("Pizza name cannot be empty")
                .Must((string name) => name.Length >= 3 && name.Length <= 20)
                .WithMessage("name must be in range [3;20]");

            RuleFor((PizzaModel pizza) => pizza.Price)
                .Must((decimal price) => price > 0)
                .WithMessage("Price must be greater than 0");

            RuleFor((PizzaModel pizza) => pizza.Description)
                .Must((string description) =>
                {
                    if (description != null && description.Length > 100)
                    {
                        return false;
                    }
                    return true;
                }).WithMessage("Description length must be smaller than 100 chars");

            RuleFor((PizzaModel pizza) => pizza.CaloryCount)
                .Must((double number) => number > 0)
                .WithMessage("calory count is mandatory");
        }
    }
}
