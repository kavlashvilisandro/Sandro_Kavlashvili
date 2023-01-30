namespace PizzaApplication.WebAPI.Infrastrucutre.Models.DTO
{
    public class PizzaDTO
    {
        public int PizzaID { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public double CaloryCount { get; set; }
        public decimal Price { get; set; }
    }
}
