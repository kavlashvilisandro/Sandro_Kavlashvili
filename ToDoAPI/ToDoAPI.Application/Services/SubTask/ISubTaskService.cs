using System;
using ToDoAPI.Application.Services.Models;

namespace ToDoAPI.Application.Services
{
    public interface ISubTaskService
    {
        public Task<int> AddSubTask(ISubTaskRequestModel model);
    }
}
