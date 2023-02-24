using System;


namespace ToDoAPI.Application.Services.Models
{
    public class SubTaskRequestModel
    {
        public int ToDoItemID { get; set; }
        public string Title { get; set; }
    }
}
