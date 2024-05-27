using PlatformCTF.Domains.Entities.User;

namespace PlatformCTF.BusinessLogic.Interfaces
{
    public interface ISessionAdmin
    {
        AdminResp AddExercise(Exercise exercise);
        AdminResp GetAllRegisteredUsers();
    }
}