using PlatformCTF.Domains.Entities.User;

namespace PlatformCTF.BusinessLogic.Interfaces
{
    public interface ISession
    { 
        ULoginResp UserLogin(ULoginData uloginData); 

        ULoginResp UserRegister(URegisterData uregisterData);
    }

}
