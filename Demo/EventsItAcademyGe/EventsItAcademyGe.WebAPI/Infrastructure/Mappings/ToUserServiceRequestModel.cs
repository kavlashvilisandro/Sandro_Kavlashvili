using Mapster;
using EventsItAcademyGe.WebAPI.Infrastructure.Models;
using EventsItAcademyGe.Application.Services.Models;

namespace EventsItAcademyGe.WebAPI.Infrastructure.Mappings
{
    public static class ToUserServiceRequestModel
    {
        public static TypeAdapterConfig UserDTOToUserRequestModel;
        static ToUserServiceRequestModel()
        {
            UserDTOToUserRequestModel = new TypeAdapterConfig();
            UserDTOToUserRequestModel.NewConfig<UserLoginRegistrationDTO, UserRequestModel>()
                .Map(dest => dest.Password, src => src.password)
                .Map(dest => dest.UserName, src => src.userName);
        }
    }
}
