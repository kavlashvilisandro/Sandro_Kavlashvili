using Mapster;
using EventsItAcademyGe.Application.Services.Models;
using EventsItAcademyGe.Domain.Models;

namespace EventsItAcademyGe.Application.Mappings
{
    public static class ToUserEntity
    {
        public static TypeAdapterConfig UserRequestToUser;

        static ToUserEntity()
        {
            UserRequestToUser = new TypeAdapterConfig();
            
            UserRequestToUser.NewConfig<IUserRequestModel, User>()
                .Map((User dest) => dest.Password, (IUserRequestModel src) => src.GetPassword())
                .Map((User dest) => dest.UserName, (IUserRequestModel src) => src.GetUserName());

        }

    }
}
