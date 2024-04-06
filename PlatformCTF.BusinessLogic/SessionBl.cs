using BusinessLogic.Core;
using PlatformCTF.BusinessLogic.Interfaces;
using PlatformCTF.Domains.Entities.User;


namespace PlatformCTF.BusinessLogic
{
    public class SessionBl : UserApi, ISession
    {
        public UserLogin UserLogin(ULoginData uLoginData)
        {
            UserLogin userLogin = new UserLogin();
            return userLogin;
        }
        public UserRegister UserRegister(URegisterData uRegisterData)
        {
            UserRegister userRegister = new UserRegister();
            return userRegister;
        }
    }
}
