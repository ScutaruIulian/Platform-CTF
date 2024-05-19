using System;
using PlatformCTF.BusinessLogic.Core;
using PlatformCTF.BusinessLogic.Interfaces;
using PlatformCTF.Domains.Entities.User;

namespace PlatformCTF.BusinessLogic
{
    public class AdminSessionBl : AdminAPI, ISessionAdmin
    {
        public AdminResp AddExercise(Exercise exercise)
        {
            return AddExerciseAction(exercise);
        }
        
        public AdminResp GetAllRegisteredUsers()
        {
            return GetAllRegisteredUsersAction();
        }
        public AdminResp BanUser(string username, TimeSpan banDuration)
        {
            return BanUserAction(username, banDuration);
        }
        
    }
}