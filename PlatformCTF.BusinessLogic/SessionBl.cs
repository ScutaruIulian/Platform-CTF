using BusinessLogic.Core;
using PlatformCTF.BusinessLogic.Interfaces;
using PlatformCTF.Domains.Entities.User;


namespace PlatformCTF.BusinessLogic
{
    public class SessionBl : UserApi, ISession
    {
        public ULoginResp UserLogin(ULoginData uLoginData)
        {
            return UserLoginAction(uLoginData);
        }
        public ULoginResp UserRegister(URegisterData uRegisterData)
        {
            return UserRegisterAction(uRegisterData);
        }
    }
}
