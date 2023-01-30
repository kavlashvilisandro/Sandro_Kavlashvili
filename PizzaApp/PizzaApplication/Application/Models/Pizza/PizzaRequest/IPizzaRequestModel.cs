using System;

namespace Application.Models
{
    public interface IPizzaRequestModel
    {
        
        public string GetName();
        public decimal GetPrice();
        public string GetDescription();
        public double GetCaloryCount();
    }
}
