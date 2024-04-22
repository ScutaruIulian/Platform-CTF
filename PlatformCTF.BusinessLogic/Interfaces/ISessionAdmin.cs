using System;
using PlatformCTF.Domains.Entities.User;

namespace PlatformCTF.BusinessLogic.Interfaces
{
    public interface ISessionAdmin
    {
        AdminResp AddExercise(Exercise exercise);
        AdminResp GetAllLoggedUsers();
        AdminResp BanUser(string username, TimeSpan banDuration);
    }
}