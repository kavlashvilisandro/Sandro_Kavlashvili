namespace ToDoAPI.WebAPI.Infrastructure.Models
{
    public class ToDoRegisterDTO
    {
        public string Title { get; set; }
        public DateTime EndDate { get; set; }

        public List<SubTaskRegisterDTO> SubTasks { get; set; }
    }
}
