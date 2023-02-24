using ToDoAPI.Application.Services.Models;
using ToDoAPI.Persistence.Models;

namespace ToDoAPI.Application.Services
{
    public interface IToDoService
    {
        public Task<int> AddToDo(IToDoRequestModel todo);
        public Task<List<ToDo>> GetAllToDos(int UserID,int? status);
        public Task<ToDo> GetToDo(int ToDoID, int UserID);

        public Task<ToDo> UpdateToDo(int UserID, int ToDoID, IToDoRequestModel model);

        public Task<object> SetToDoAsDone(int UserID, int ToDoID);

        public Task<object> DeleteToDo(int UserID, int ToDoID);
    }
}
