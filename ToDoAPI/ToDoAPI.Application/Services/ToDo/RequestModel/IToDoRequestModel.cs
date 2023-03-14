using System;


namespace ToDoAPI.Application.Services.Models
{
    public interface IToDoRequestModel
    {
        public int GetID();
        public string GetTitle();
        public DateTime GetEndDate();
        public List<SubTaskRequestModel> GetSubTasks();
        public int GetOwnerID();
    }
}
