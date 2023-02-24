namespace ToDoAPI.WebAPI.Infrastructure.Models
{
    public class ToDoModel
    {
        public int OwnerID { get; set; }
        public int ToDoID { get; set; }
        public string Title { get; set; }
        public DateTime EndDate { get; set; }

        public List<SubTaskModel> SubTasks { get; set; } = new List<SubTaskModel>();
    }
}
