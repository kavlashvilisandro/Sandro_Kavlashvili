using System;


namespace ToDoAPI.Persistence.Models.Abstraction
{
    public abstract class BaseEntity
    {
        public int ID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime ModifiedAt { get; set; } = DateTime.Now;

    }
}
