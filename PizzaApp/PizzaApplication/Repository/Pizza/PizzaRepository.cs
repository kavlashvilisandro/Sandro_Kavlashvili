using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Pizza
{
    public static class PizzaRepository
    {
        public async static Task<int> AddPizzaAsync(PizzaModel pizza)
        {
            pizza.PizzaID = DBContext.PizzaIDCounter++;
            DBContext.pizzas.Add(pizza);
            return pizza.PizzaID;
        }

        public async static Task<PizzaModel> GetPizzaAsync(int id)
        {
            if (DBContext.pizzas.Count((x) => x.PizzaID == id) == 1)
            {
                return DBContext.pizzas.Single((x) => x.PizzaID == id);
            }
            else
            {
                return null;
            }
        }


    }
}
