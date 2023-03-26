
namespace EventsItAcademyGe.Domain.Exceptions
{
    public class DataValidationException : CustomException
    {
        public DataValidationException(string message)
            : base(message, 400)
        {

        }
    }
}
