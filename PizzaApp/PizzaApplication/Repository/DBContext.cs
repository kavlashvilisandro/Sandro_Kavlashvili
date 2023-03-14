using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Models;
using Repository.Pizza;

namespace Repository
{
    public static class DBContext
    {
        public static int UserIDCounter = 1;
        public static int PizzaIDCounter = 1;
        public static List<UserModel> users = new List<UserModel>();
        public static List<PizzaModel> pizzas = new List<PizzaModel>();
    }
}
