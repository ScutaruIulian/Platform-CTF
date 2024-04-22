using PlatformCTF.BusinessLogic.Interfaces;


namespace PlatformCTF.BusinessLogic
{
    public class BusinessLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBl();
        }
        public ISessionAdmin GetSessionAdminBL()
        {
            return new AdminSessionBl();
        }
    }
}
