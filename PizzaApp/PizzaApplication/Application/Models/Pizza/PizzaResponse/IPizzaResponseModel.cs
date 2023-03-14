using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Pizza
{
    public interface IPizzaResponseModel
    {
        public int GetID();
        public string GetName();
        public decimal GetPrice();
        public string GetDescription();
        public double GetCaloryCount();
    }
}
