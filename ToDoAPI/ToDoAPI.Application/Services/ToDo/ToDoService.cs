using ToDoAPI.Application.Services.Models;
using ToDoAPI.Infrastructure.Repos;
using ToDoAPI.Persistence.Models;
using ToDoAPI.Application.Infrastructure.Mapping;
using Mapster;

namespace ToDoAPI.Application.Services
{
    public class ToDoService : IToDoService
    {

        private readonly IServiceProvider _provider;
        private readonly ToDoRepo _toDoRepo;
        public ToDoService(IServiceProvider provider)
        {
            this._provider = provider;
            this._toDoRepo = new ToDoRepo(provider);
        }



        //აბრუნებს დამატებული ToDo-ს ID-ს
        public async Task<int> AddToDo(IToDoRequestModel todo)
        {
            return await _toDoRepo.AddAsync(todo.Adapt<ToDo>(ToDoMappings.ToDoRequestModelToTable));
        }

        public async Task<List<ToDo>> GetAllToDos(int UserID, int? status)
        {
            IQueryable<ToDo> data = null;
            if (status != null)
            {
                data = await _toDoRepo.FilterDataWithIncludes
                (
                        (ToDo item) => item.Status == status && item.OwnerID == UserID
                        , withTracking: false
                );
            }
            else
            {
                data = await _toDoRepo.FilterDataWithIncludes
                (
                        (ToDo item) => item.OwnerID == UserID && item.Status != (int)Statuses.Deleted
                        , withTracking: false
                );
            }
            List<ToDo> Result = await _toDoRepo.ToList(data);
            return Result;
        }

        public async Task<ToDo> GetToDo(int ToDoID, int UserID)
        {
            IQueryable<ToDo> data = await _toDoRepo.FilterDataWithIncludes((x) => x.ID == ToDoID && x.OwnerID == UserID, false);
            //თუ ზუსტად 1 ცალი არ იქნება, ერორს გაისვრის
            ToDo item = data.Single((x) => x.ID == ToDoID && x.OwnerID == UserID);
            item.Owner = null;
            return item;
        }

        public async Task<ToDo> UpdateToDo(int UserID, int ToDoID, IToDoRequestModel model)
        {
            IQueryable<ToDo> data = await _toDoRepo.FilterData((x) => x.ID == ToDoID && x.OwnerID == UserID, true);

            ToDo item = data.Single((x) => x.ID == ToDoID && x.OwnerID == UserID);

            Console.WriteLine(model.GetEndDate());//<-------

            if(model.GetEndDate() != default(DateTime))
            {
                item.EndDate = model.GetEndDate();
            }
            if(model.GetTitle() != null)
            {
                item.Title = model.GetTitle();
            }
            item.ModifiedAt = DateTime.Now;
            await _toDoRepo.SaveChangesAsync();

            return item;

        }

        public async Task<object> SetToDoAsDone(int UserID, int ToDoID)
        {
            if(await _toDoRepo.Exists((ToDo x) => x.ID == ToDoID && x.OwnerID == UserID && x.Status != 3))
            {
                ToDo item = new ToDo();
                item.ID = ToDoID;
                _toDoRepo.Attach(item);
                item.Status = (int)Statuses.Done;//entity state = modified
                await _toDoRepo.SaveChangesAsync();
                return new { message = "Operation success" };
            }
            else
            {
                return new {message = "There is not ToDo with this id"};
            }
        }

        public async Task<object> DeleteToDo(int UserID, int ToDoID)
        {
            if (await _toDoRepo.Exists((ToDo x) => x.ID == ToDoID && x.OwnerID == UserID && x.Status != 3))
            {
                ToDo item = new ToDo();
                item.ID = ToDoID;
                _toDoRepo.Attach(item);
                item.Status = (int)Statuses.Deleted;//entity state = modified
                await _toDoRepo.SaveChangesAsync();
                _toDoRepo.Detach(item);
                return new { message = "Operation success" };
            }
            else
            {
                return new { message = "There is not ToDo with this id" };
            }
        }

        
        
    }
}
