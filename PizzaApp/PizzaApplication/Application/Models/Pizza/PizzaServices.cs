using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Pizza;
namespace Application.Models.Pizza
{
    public class PizzaServices : IPizzaServices
    {
        public async Task<int> AddPizza(IPizzaRequestModel pizza)
        {
            PizzaModel newPizza = new PizzaModel()
            {
                Name = pizza.GetName(),
                Price = pizza.GetPrice(),
                CaloryCount = pizza.GetCaloryCount(),
                Description = pizza.GetDescription(),
            };
            return await PizzaRepository.AddPizzaAsync(newPizza);

        }

        public async Task<IPizzaResponseModel> GetPizza(int id)
        {
            PizzaModel res = await PizzaRepository.GetPizzaAsync(id);
            return new PizzaResponseModel()
            {
                Name = res.Name,
                Price = res.Price,
                CaloryCount = res.CaloryCount,
                ID = res.PizzaID,
                Description = res.Description,
            };
        }
    }
}
