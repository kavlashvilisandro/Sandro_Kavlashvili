using System;
using ToDoAPI.Persistence.Models.Abstraction;

namespace ToDoAPI.Persistence.Models
{
    public class SubTask : BaseEntity
    {
        public string Title { get; set; }
        public int ToDoItemID { get; set; }
        public ToDo SubTaskOwnerToDo { get; set; }
    }
}
