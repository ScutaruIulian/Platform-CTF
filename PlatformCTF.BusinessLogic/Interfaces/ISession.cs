using System.Web;
using PlatformCTF.Domain.Entities.User;
using PlatformCTF.Domains.Entities.User;

namespace PlatformCTF.BusinessLogic.Interfaces
{
    public interface ISession
    { 
        ULoginResp UserLogin(ULoginData uloginData); 
        HttpCookie GenCookie(string loginCredential);
        UserMinimal GetUserByCookie(string apiCookieValue);
        ULoginResp UserRegister(URegisterData uregisterData);
        object GetAllUsers();
        object GetUserById(int id);
        void BanUser(int id);
        object GetAllSessions();
        void DeleteSession(int id);
    }

}
