using BusinessLogic.Interfaces;

namespace BusinessLogic
{
    public class BusinessLogic
    {
        public ISession GetSessionBl()
        {
            return new SessionBl();
        }
    }
}