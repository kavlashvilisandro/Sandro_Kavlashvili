using System;
using ToDoAPI.Persistence.Models;

namespace ToDoAPI.Infrastructure.Repos
{
    public class ToDoRepo : BaseRepo<ToDo>
    {
        public ToDoRepo(IServiceProvider provider) : base(provider)
        {

        }
    }
}
