namespace PizzaApplication.WebAPI.Infrastrucutre.Models
{
    public class OrderModel
    {
        public int UserID { get; set; }
        public int AddressID { get; set; }
        public List<int> ListOfPizzaIDs { get; set; }
    }
}
