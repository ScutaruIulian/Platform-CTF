using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AutoMapper;
using PlatformCTF.BusinessLogic.DBModel.Seed;
using PlatformCTF.Domain.Entities.User;
using PlatformCTF.Domains.Entities.User;
using PlatformCTF.Domains.Enums;
using PlatformCTF.Helpers;

namespace PlatformCTF.BusinessLogic.Core
{
    public class UserApi
    {
        internal ULoginResp UserLoginAction(ULoginData data)
        {
            if (data == null) return new ULoginResp { Status = false, StatusMsg = "Data is null" };

            if (!new EmailAddressAttribute().IsValid(data.Credentials) &&
                !new RegularExpressionAttribute(@"^[a-zA-Z0-9]*$").IsValid(data.Credentials))
                return new ULoginResp { Status = false, StatusMsg = "The credentials are not valid" };

            if (!new RegularExpressionAttribute(@"^[a-zA-Z0-9]*$").IsValid(data.Password))
                return new ULoginResp { Status = false, StatusMsg = "Password is not valid " };

            UDBTable user;
            var validate = new EmailAddressAttribute();
            var hashedPassword = LoginHelper.HashGen(data.Password);
            using (var db = new UserContext())
            {
                user = db.Users.FirstOrDefault(u => u.Email == data.Credentials && u.Password == hashedPassword);
            }

            if (user == null)
                return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };

            using (var todo = new UserContext())
            {
                user.LastIp = data.LoginIp;
                user.LastLogin = data.LoginDateTime;
                todo.Entry(user).State = EntityState.Modified;
                todo.SaveChanges();
            }

            using (var db = new SessionContext())
            {
                db.Sessions.Add(new Session
                {
                    UserId = user.Id,
                    CookieString = CookieGenerator.Create(data.Credentials),
                    ExpireTime = DateTime.Now.AddMinutes(60)
                });

                db.SaveChanges();
                var apiCookie = Cookie(data.Credentials);
                HttpContext.Current.Response.Cookies.Add(apiCookie);
            }

            return new ULoginResp { Status = true };
        }

        internal HttpCookie Cookie(string loginCredential)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(loginCredential)
            };

            using (var db = new UserContext())
            {
                UDBTable currentUser;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(loginCredential))
                    currentUser = db.Users.FirstOrDefault(u => u.Email == loginCredential);
                else
                    currentUser = db.Users.FirstOrDefault(u => u.Username == loginCredential);

                if (currentUser != null)
                {
                    var currentSession = db.Sessions.FirstOrDefault(s => s.UserId == currentUser.Id);
                    if (currentSession != null)
                    {
                        currentSession.CookieString = apiCookie.Value;
                        currentSession.ExpireTime = DateTime.Now.AddMinutes(60);
                    }
                    else
                    {
                        db.Sessions.Add(new Session
                        {
                            UserId = currentUser.Id,
                            CookieString = apiCookie.Value,
                            ExpireTime = DateTime.Now.AddMinutes(60)
                        });
                    }

                    db.SaveChanges();
                }
            }

            return apiCookie;
        }

        internal UserMinimal UserCookie(string cookie)
        {
            Session session;
            UDBTable currentUser;

            using (var db = new UserContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;

            using (var db = new UserContext())
            {
                currentUser = db.Users.FirstOrDefault(u => u.Id == session.UserId);
            }

            if (currentUser == null) return null;

            var config = new MapperConfiguration(cfg => cfg.CreateMap<UDBTable, UserMinimal>());
            var mapper = config.CreateMapper();
            var userminimal = mapper.Map<UserMinimal>(currentUser);

            return userminimal;
        }

        internal ULoginResp UserRegisterAction(URegisterData data)
        {
            UDBTable user;

            using (var db = new UserContext())
            {
                user = db.Users.FirstOrDefault(u => u.Username == data.Username);
            }

            if (user != null) return new ULoginResp { Status = false, StatusMsg = "User already exists" };

            var hashedPassword = LoginHelper.HashGen(data.Password);

            user = new UDBTable
            {
                Username = data.Username,
                Password = hashedPassword,
                Email = data.Email,
                Level = URole.Admin,
                LastIp = data.IpAddress,
                LastLogin = DateTime.Now,
                Score = 0
            };

            using (var db = new UserContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            return new ULoginResp { Status = true, StatusMsg = "User registered successfully" };
        }

        public ULoginResp ShowAllExercisesAction()
        {
            var exercises = new List<Exercise>();
            using (var db = new ExerciseContext())
            {
                exercises = db.Exercises.ToList();
            }

            if (exercises.Count > 0)
                return new ULoginResp
                    { Status = true, StatusMsg = "Exercises fetched successfully", Exercises = exercises };
            return new ULoginResp { Status = false, StatusMsg = "No exercises are currently available" };
        }

        public ULoginResp SubmitFlagAction(int challengeId, string submittedFlag)
        {
            Exercise challenge;
            using (var db = new ExerciseContext())
            {
                challenge = db.Exercises.FirstOrDefault(e => e.Id == challengeId);
            }

            if (challenge == null) return new ULoginResp { Status = false, StatusMsg = "Challenge not found" };

            if (challenge.Flag == submittedFlag)
                return new ULoginResp { Status = true, StatusMsg = "Correct flag!" };
            return new ULoginResp { Status = false, StatusMsg = "Incorrect flag." };
        }
        internal List<UDBTable> GetAllUsersPoints()
        {
            List<UDBTable> users;

            using (var db = new UserContext())
            {
                users = db.Users.OrderByDescending(user => user.Score).ToList();
            }

            return users;
        }
    }
}