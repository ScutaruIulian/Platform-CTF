using PlatformCTF.BusinessLogic.Interfaces;


namespace PlatformCTF.BusinessLogic
{
    public class BusinessLogic
    {
        public ISession GetSessionBL()
        {
            return new SessionBl();
        }
    }
}
