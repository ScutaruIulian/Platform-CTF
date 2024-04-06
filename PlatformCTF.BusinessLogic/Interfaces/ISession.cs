using PlatformCTF.Domains.Entities.User;

namespace PlatformCTF.BusinessLogic.Interfaces
{
    public interface ISession
    { 
        bool UserLogin(ULoginData uloginData); 

        bool UserRegister(URegisterData uregisterData);
    }

}
