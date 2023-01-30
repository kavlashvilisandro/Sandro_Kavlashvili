using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models.Pizza
{
    public interface IPizzaServices
    {
        public Task<IPizzaResponseModel> GetPizza(int id);

        public Task<int> AddPizza(IPizzaRequestModel pizza);
    }
}
