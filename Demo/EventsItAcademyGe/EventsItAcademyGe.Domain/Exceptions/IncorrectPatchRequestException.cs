namespace EventsItAcademyGe.Domain.Exceptions
{
    public class IncorrectPatchRequestException : CustomException
    {
        public IncorrectPatchRequestException(string message) 
            : base(message, 400)
        {

        }
    }
}
