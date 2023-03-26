
namespace EventsItAcademyGe.Domain.Exceptions
{
    public class APIRequestError : CustomException
    {
        public APIRequestError(string message, int statusCode)
            :base(message, statusCode)
        {

        }
    }
}
