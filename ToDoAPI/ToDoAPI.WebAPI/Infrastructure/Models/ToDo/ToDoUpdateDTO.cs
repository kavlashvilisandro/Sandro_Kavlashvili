namespace ToDoAPI.WebAPI.Infrastructure.Models
{
    public class ToDoUpdateDTO
    {
        //Title optional
        public string? Title { get; set; } = null;


        //EndDate optional
        public DateTime? EndDate { get; set; } = default;
    }
}
