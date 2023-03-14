using System;
using ToDoAPI.Persistence.Models.Abstraction;

namespace ToDoAPI.Persistence.Models
{
    public class Status : BaseEntity
    {
        public string StatusDefinition { get; set; }
    }
}
