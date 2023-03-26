
namespace EventsItAcademyGe.Domain.Exceptions
{
    public class IncorrectDaysAmountException : CustomException
    {
        public IncorrectDaysAmountException() 
            : base("Days amount should be more than 0", 400)
        {

        }
    }
}
