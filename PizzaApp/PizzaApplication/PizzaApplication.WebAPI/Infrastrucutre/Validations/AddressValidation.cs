using FluentValidation;
using PizzaApplication.WebAPI.Infrastrucutre.Models;

namespace PizzaApplication.WebAPI.Infrastrucutre.Validations
{
    public class AddressValidation : AbstractValidator<AddressModel>
    {
        public AddressValidation()
        {
            RuleFor((AddressModel address) => address.UserID)
                .Must((int id) => true)//Check if id exists in DB
                .WithMessage("Address doesnot exists in Data base")
                .Must((id) => id >= 1).WithMessage("Id must be greater or equal to 1");


            RuleFor((AddressModel address) => address.City)
                .NotEmpty()
                .Must((city) => city.Length <= 15)
                .WithMessage("city length must be smaller than 15");

            RuleFor((AddressModel address) => address.Country)
                .NotEmpty()
                .Must((Country) => Country.Length <= 15)
                .WithMessage("Country length must be smaller than 15");

            RuleFor((AddressModel address) => address.Region)
                .Must((Region) =>
                {
                    if(Region != null)
                    {
                        return Region.Length <= 15;
                    }
                    return true;
                })
                .WithMessage("Region length must be smaller than 15");

            RuleFor((AddressModel address) => address.Description)
                .Must((Description) =>
                {
                    if (Description != null)
                    {
                        return Description.Length <= 100;
                    }
                    return true;
                })
                .WithMessage("Description length must be smaller than 100");

        }
    }
}
