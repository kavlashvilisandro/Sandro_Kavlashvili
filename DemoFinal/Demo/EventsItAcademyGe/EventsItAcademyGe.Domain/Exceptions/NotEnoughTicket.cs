
namespace EventsItAcademyGe.Domain.Exceptions
{
    public class NotEnoughTicket : CustomException
    {
        public NotEnoughTicket() : 
            base("There are not enough tickets", 400)
        {

        }
    }
}
