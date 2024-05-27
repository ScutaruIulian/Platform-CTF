using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PlatformCTF.BusinessLogic.DBModel.Seed;
using PlatformCTF.Domains.Entities.User;

namespace PlatformCTF.BusinessLogic.Core
{
    public class AdminAPI
    {
        internal AdminResp AddExerciseAction(Exercise data)
        {
            Exercise challenge;

            using (var db = new ExerciseContext())
            {
                challenge = db.Exercises.FirstOrDefault(e => e.Name == data.Name);
            }

            if (challenge != null)
                return new AdminResp { Status = false, StatusMsg = "Exercise with this name already exists" };

            using (var db = new ExerciseContext())
            {
                Database.SetInitializer(new CreateDatabaseIfNotExists<ExerciseContext>());
                db.Exercises.Add(data);
                db.SaveChanges();
            }

            return new AdminResp { Status = true, StatusMsg = "Exercise added successfully" };
        }


        public AdminResp GetAllRegisteredUsersAction()
        {
            var registeredUsers = new List<UDBTable>();
            using (var db = new UserContext())
            {
                registeredUsers = db.Users.ToList();
            }

            if (registeredUsers.Count > 0)
                return new AdminResp
                    { Status = true, StatusMsg = "Registered users fetched successfully", Users = registeredUsers };
            return new AdminResp { Status = false, StatusMsg = "No users are currently registered" };
        }
    }
}