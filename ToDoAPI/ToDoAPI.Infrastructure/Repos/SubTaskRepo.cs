using System;
using ToDoAPI.Persistence.Models;

namespace ToDoAPI.Infrastructure.Repos
{
    public class SubTaskRepo : BaseRepo<SubTask>
    {
        public SubTaskRepo(IServiceProvider provider) : base(provider)
        {

        }
    }
}
