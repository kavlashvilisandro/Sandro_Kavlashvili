using System;
using Mapster;
using ToDoAPI.Persistence.Models;
using ToDoAPI.Application.Services.Models;

namespace ToDoAPI.Application.Infrastructure.Mapping
{
    public static class UserMapping
    {
        public static readonly TypeAdapterConfig UserToEntity;


        static UserMapping()
        {
            UserToEntity = new TypeAdapterConfig();
            UserToEntity.NewConfig<IUserRequestModel, User>()
                .Map((User src) => src.UserName, (IUserRequestModel src) => src.GetUserName())
                .Map((User src) => src.PasswordHash, (IUserRequestModel src) => src.GetPassword())
                .IgnoreNonMapped(true);
        }
    }
}
