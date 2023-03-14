using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Pizza
{
    public class PizzaModel
    {
        public int PizzaID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public double CaloryCount { get; set; }
        
    }
}
