﻿using PlatformCTF.BusinessLogic.Interfaces;
using PlatformCTF.Domains.Entities.User;
using System.Web;
using PlatformCTF.BusinessLogic.Core;
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
        public ULoginResp ShowAllExercises()
        {
            return ShowAllExercisesAction();
        }
        public ULoginResp SubmitFlag(int challengeId, string submittedFlag)
        {
            return SubmitFlagAction(challengeId, submittedFlag);
        }
    }
}