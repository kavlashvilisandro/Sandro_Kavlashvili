using FluentValidation;
using PizzaApplication.WebAPI.Infrastrucutre.Models;

namespace PizzaApplication.WebAPI.Infrastrucutre.Validations
{
    public class OrderValidator : AbstractValidator<OrderModel>
    {
        public OrderValidator()
        {
            RuleFor((OrderModel model) => model.UserID)
                .Must((int id) => true)//Check if id is in database
                .WithMessage("UserID must be in DB");

            RuleFor((OrderModel model) => model.AddressID)
                .Must((int id) => true)//Check if id is in database
                .WithMessage("AddressID must be in DB");

            RuleFor((OrderModel model) => model.ListOfPizzaIDs)
                .Must((List<int> collection) => collection != null && collection.Count != 0)
                .WithMessage("Pizza order list must not be empty")
                .Must((List<int> id) => true)//Check if ids are in database
                .WithMessage("All pizza ids must be in DB");
        }
    }
}
