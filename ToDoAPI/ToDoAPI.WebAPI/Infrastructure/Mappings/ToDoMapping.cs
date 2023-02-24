using Mapster;
using ToDoAPI.WebAPI.Infrastructure.Models;

namespace ToDoAPI.WebAPI.Infrastructure.Mappings
{
    public static class ToDoMapping
    {
        public static TypeAdapterConfig FromToDoRegisterToModel;
        private static TypeAdapterConfig FromSubTaskRegisterToModel;
        static ToDoMapping()
        {

            FromSubTaskRegisterToModel = new TypeAdapterConfig();
            FromToDoRegisterToModel = new TypeAdapterConfig();



            FromSubTaskRegisterToModel.NewConfig<SubTaskRegisterDTO, SubTaskModel>()
                .Map((dest) => dest.Title, (src) => src.Title)
                .IgnoreNonMapped(true);



            FromToDoRegisterToModel.NewConfig<ToDoRegisterDTO, ToDoModel>()
                .Map((ToDoModel dest) => dest.Title, (ToDoRegisterDTO src) => src.Title)
                .Map((ToDoModel dest) => dest.EndDate, (src) => src.EndDate)
                .Map((dest) => dest.SubTasks, (src) => src.SubTasks.Adapt<List<SubTaskModel>>(FromSubTaskRegisterToModel))
                .IgnoreNonMapped(true);
        }
    }
}
