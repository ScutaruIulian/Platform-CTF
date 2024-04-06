using BusinessLogic.Core;
using PlatformCTF.BusinessLogic.Interfaces;
using PlatformCTF.Domains.Entities.User;


namespace PlatformCTF.BusinessLogic
{
    public class SessionBl : UserApi, ISession
    {
        public bool UserLogin(ULoginData uLoginData)
        {
            return true;
        }
        public bool UserRegister(URegisterData uRegisterData)
        {
            return true;
        }
    }
}
