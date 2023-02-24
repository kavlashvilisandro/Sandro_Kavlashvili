using System;
using ToDoAPI.Application.Services.Models;
using ToDoAPI.Infrastructure.Repos;
using ToDoAPI.Persistence.Models;

namespace ToDoAPI.Application.Services
{
    public class SubTaskService : ISubTaskService
    {

        private readonly IServiceProvider _serviceProvider;
        private readonly SubTaskRepo _subTaskRepo;
        private readonly ToDoRepo _toDoRepo;
        
        public SubTaskService(IServiceProvider provider)
        {
            this._serviceProvider = provider;
            this._subTaskRepo = new SubTaskRepo(provider);
            this._toDoRepo = new ToDoRepo(provider);
        }




        //Returns id of added subtask
        public async Task<int> AddSubTask(ISubTaskRequestModel model)
        {
            if(!(await _toDoRepo.Exists((ToDo item) => item.ID == model.GetToDoItemID() && item.Status != (int)Statuses.Deleted)))
            {
                throw new Exception("There is not todo with this id");
            }
            SubTask subTask = new SubTask();//ID 0-ია, ამიტომაც ავტომატურად
            //insert მოხდება.
            _subTaskRepo.Attach(subTask);
            subTask.Title = model.GetTitle();//state modified
            subTask.ToDoItemID = model.GetToDoItemID();//state modified
            await _subTaskRepo.SaveChangesAsync();//დაინსერტდა და გაესეტა ID
            //და გადავიდა ამ subTask entity-ის state unchanged-ზე
            return subTask.ID;
        }
    }
}
