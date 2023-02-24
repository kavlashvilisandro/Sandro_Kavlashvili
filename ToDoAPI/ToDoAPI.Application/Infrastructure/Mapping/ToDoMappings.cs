using System;
using Mapster;
using ToDoAPI.Persistence.Models;
using ToDoAPI.Application.Services.Models;

namespace ToDoAPI.Application.Infrastructure.Mapping
{
    public static class ToDoMappings
    {
        public static readonly TypeAdapterConfig ToDoRequestModelToTable;
        public static readonly TypeAdapterConfig SubTaskRequestModelToTable;

        static ToDoMappings()
        {
            ToDoRequestModelToTable = new TypeAdapterConfig();
            SubTaskRequestModelToTable = new TypeAdapterConfig();

            SubTaskRequestModelToTable.NewConfig<SubTaskRequestModel, SubTask>()
                .Map(dest => dest.Title, src => src.Title)
                .Map(dest => dest.ToDoItemID, src => src.ToDoItemID)
                .IgnoreNonMapped(true);

            ToDoRequestModelToTable.NewConfig<IToDoRequestModel, ToDo>()
                .Map(dest => dest.Title, src => src.GetTitle())
                .Map(dest => dest.EndDate, src => src.GetEndDate())
                .Map(dest => dest.OwnerID, src => src.GetOwnerID())
                .Map(dest => dest.SubTasks, src => src.GetSubTasks().Adapt<List<SubTask>>(SubTaskRequestModelToTable))
                .IgnoreNonMapped(true);
        }


    }
}
