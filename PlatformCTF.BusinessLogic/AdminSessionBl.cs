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
    }
}