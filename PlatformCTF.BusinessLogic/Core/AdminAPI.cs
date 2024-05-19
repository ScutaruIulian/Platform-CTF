using System;
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
            {
                return new AdminResp { Status = false, StatusMsg = "Exercise with this name already exists" };
            }

            challenge = new Exercise
            {
                Name = data.Name,
                Description = data.Description,
                DownloadLink = data.DownloadLink,
                Category = data.Category,
                Level = data.Level,
                Flag = data.Flag,
                Points = data.Points
            };
            using (var db = new ExerciseContext())
            {
                db.Exercises.Add(challenge);
                db.SaveChanges();
            }

            return new AdminResp { Status = true, StatusMsg = "Exercise added successfully" };
        }


        public AdminResp GetAllRegisteredUsersAction()
        {
            List<UDBTable> registeredUsers = new List<UDBTable>();
            using (var db = new UserContext())
            {
                registeredUsers = db.Users.ToList();
            }

            if (registeredUsers.Count > 0)
            {
                return new AdminResp
                    { Status = true, StatusMsg = "Registered users fetched successfully", Users = registeredUsers };
            }
            else
            {
                return new AdminResp { Status = false, StatusMsg = "No users are currently registered" };
            }
        }

        public AdminResp BanUserAction(string username, TimeSpan banDuration)
        {
            using (var db = new UserContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Username == username);
                if (user != null)
                {
                    user.BanEndTime = DateTime.Now.Add(banDuration);
                    user.IsBanned = true;

                    var userSession = db.Sessions.FirstOrDefault(s => s.UserId == user.Id);
                    if (userSession != null)
                    {
                        db.Sessions.Remove(userSession);
                    }

                    db.SaveChanges();
                    return new AdminResp { Status = true, StatusMsg = "User banned successfully" };
                }
                else
                {
                    return new AdminResp { Status = false, StatusMsg = "User not found" };
                }
            }
        }
    }
}