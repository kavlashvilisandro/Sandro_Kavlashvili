using System;

namespace ToDoAPI.Application.Services.Models
{
    public class ToDoRequestModel : IToDoRequestModel
    {
        public int OwnerID { get; set; }
        public int ToDoID { get; set; }
        public string Title { get; set; }
        public DateTime EndDate { get; set; }

        public List<SubTaskRequestModel> SubTasks { get; set; } = new List<SubTaskRequestModel>();

        public DateTime GetEndDate()
        {
            return this.EndDate;
        }

        public int GetID()
        {
            return this.OwnerID;
        }

        public string GetTitle()
        {
            return this.Title;
        }

        public List<SubTaskRequestModel> GetSubTasks()
        {
            return this.SubTasks;
        }
        public int GetOwnerID()
        {
            return this.OwnerID;
        }
    }
}
