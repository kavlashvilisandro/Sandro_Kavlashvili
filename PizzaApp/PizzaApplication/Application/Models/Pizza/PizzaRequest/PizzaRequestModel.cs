using System;


namespace Application.Models
{
    public class PizzaRequestModel : IPizzaRequestModel
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public double CaloryCount { get; set; }

        public double GetCaloryCount()
        {
            return this.CaloryCount;
        }

        public string GetDescription()
        {
            return this.Description;
        }

        public string GetName()
        {
            return this.Name;
        }

        public decimal GetPrice()
        {
            return this.Price;
        }
    }
}
