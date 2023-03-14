using System;


namespace ToDoAPI.Application.Services.Models
{
    public class SubTaskRequest : ISubTaskRequestModel
    {
        public int ToDoItemID { get; set; }
        public string Title { get; set; }

        public int GetToDoItemID()
        {
            return this.ToDoItemID;
        }

        public string GetTitle()
        {
            return this.Title;
        }
    }
}
