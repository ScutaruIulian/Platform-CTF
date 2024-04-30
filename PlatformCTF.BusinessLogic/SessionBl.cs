using BusinessLogic.Core;
using PlatformCTF.BusinessLogic.Interfaces;
using PlatformCTF.Domains.Entities.User;
using System;
using System.Web;
using PlatformCTF.Domain.Entities.User;


namespace PlatformCTF.BusinessLogic
{
    public class SessionBl : UserApi, ISession
    {
        public ULoginResp UserLogin(ULoginData uLoginData)
        {
            return UserLoginAction(uLoginData);
        }

        public HttpCookie GenCookie(string loginCredential)
        {
            return Cookie(loginCredential);
        }

        public UserMinimal GetUserByCookie(string apiCookieValue)
        {
            return UserCookie(apiCookieValue);
        }

        public ULoginResp UserRegister(URegisterData uRegisterData)
        {
            return UserRegisterAction(uRegisterData);
        }
    }
}