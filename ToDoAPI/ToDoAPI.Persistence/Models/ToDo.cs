using System;
using ToDoAPI.Persistence.Models.Abstraction;

namespace ToDoAPI.Persistence.Models
{
    public enum Statuses
    {
        Active = 1,
        Done = 2,
        Deleted = 3
    }
    public class ToDo : BaseEntity
    {

        public string Title { get; set; }

        public int Status { get; set; } = (int)Statuses.Active;

        public DateTime EndDate { get; set; }

        public int OwnerID { get; set; }

        public List<SubTask> SubTasks { get; set; }

        public User Owner { get; set; }

    }
}
