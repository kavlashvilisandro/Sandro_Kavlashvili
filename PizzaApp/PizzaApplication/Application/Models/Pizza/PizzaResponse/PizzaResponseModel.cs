using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Pizza
{
    public class PizzaResponseModel : IPizzaResponseModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public double CaloryCount { get; set; }
        public double GetCaloryCount()
        {
            return this.CaloryCount;
        }
        public int GetID()
        {
            return this.ID;
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
