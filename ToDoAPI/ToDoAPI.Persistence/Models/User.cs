using System;
using ToDoAPI.Persistence.Models.Abstraction;

namespace ToDoAPI.Persistence.Models
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }

        public string PasswordHash { get; set; }

        public List<ToDo> ToDoTasks { get; set; }

        

    }
}
