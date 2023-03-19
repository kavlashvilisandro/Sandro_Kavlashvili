
namespace EventsItAcademyGe.Domain.Exceptions
{
    public abstract class CustomException : Exception
    {
        protected int StatusCode;
        public CustomException(string message, int statuscode) : base(message)
        {
            this.StatusCode = statuscode;
        }

        public int GetStatusCode()
        {
            return this.StatusCode;
        }
    }
}
