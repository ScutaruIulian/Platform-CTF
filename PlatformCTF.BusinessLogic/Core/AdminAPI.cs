using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using PlatformCTF.BusinessLogic.DBModel.Seed;
using PlatformCTF.Domains.Entities.User;
using PlatformCTF.Domain.Entities.User;

namespace PlatformCTF.BusinessLogic.Core
{
    public class AdminAPI
    {
        public AdminResp AddExerciseAction(Exercise exercise)
        {
            using (var db = new ExerciseContext())
            {
                db.Exercises.Add(exercise);
                db.SaveChanges();
            }

            return new AdminResp { Status = true, StatusMsg = "Exercise added" };
        }


        public AdminResp GetAllLoggedUsersAction()
        {
            List<UDBTable> loggedUsers = new List<UDBTable>();
            using (var db = new UserContext())
            {
                var validSessions = db.Sessions.Where(s => s.ExpireTime > DateTime.Now).ToList();
                foreach (var session in validSessions)
                {
                    var user = db.Users.FirstOrDefault(u => u.Id == session.UserId);
                    if (user != null)
                    {
                        loggedUsers.Add(user);
                    }
                }
            }

            if (loggedUsers.Count > 0)
            {
                return new AdminResp
                    { Status = true, StatusMsg = "Logged users fetched successfully", Users = loggedUsers };
            }
            else
            {
                return new AdminResp { Status = false, StatusMsg = "No users are currently logged in" };
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