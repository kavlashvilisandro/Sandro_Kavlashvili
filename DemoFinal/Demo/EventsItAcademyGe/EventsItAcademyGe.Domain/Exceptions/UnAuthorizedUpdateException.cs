namespace EventsItAcademyGe.Domain.Exceptions
{
    public class UnAuthorizedUpdateException : CustomException
    {
        public UnAuthorizedUpdateException(string propertyName)
            :base($"You cannot update '{propertyName}", 401)
        {

        }
    }
}
