
namespace EventsItAcademyGe.Domain.Exceptions
{
    public class AdminNotFoundException : CustomException
    {
        public AdminNotFoundException()
            :base("Admin not found with this credentials", 400)
        {

        }
    }
}
