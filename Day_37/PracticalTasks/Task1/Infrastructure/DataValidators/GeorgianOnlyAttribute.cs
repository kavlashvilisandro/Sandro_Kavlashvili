using System.ComponentModel.DataAnnotations;

namespace Task1.Infrastructure.DataValidators
{
    public class GeorgianOnlyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            if(value != null)
            {
                if(value is string)
                {
                    string DownCastedValue = (string)value;
                    for(int i = 0; i < DownCastedValue.Length; i++)
                    {
                        if(DownCastedValue[i] > 'ჰ' || DownCastedValue[i] < 'ა')
                        {
                            return new ValidationResult("There is not all georgian symbols");
                        }
                    }
                    return ValidationResult.Success;
                }
                else
                {
                    return new ValidationResult("Data is not string");
                }
                
            }
            return new ValidationResult("Data is null");
        }
    }
}
