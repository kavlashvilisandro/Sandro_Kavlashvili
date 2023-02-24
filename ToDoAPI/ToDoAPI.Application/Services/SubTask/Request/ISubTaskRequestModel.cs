using System;


namespace ToDoAPI.Application.Services.Models
{
    public interface ISubTaskRequestModel
    {
        public int GetToDoItemID();
        public string GetTitle();
    }
}
