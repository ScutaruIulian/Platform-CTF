using System;
using PlatformCTF.BusinessLogic.DBModel;
using PlatformCTF.Domains.Entities.User;
using PlatformCTF.Domains.Enums;
using System.Linq;
using AutoMapper;
using System.Web;
using PlatformCTF.Helpers;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.Entity;
using PlatformCTF.Domain.Entities.User;

namespace BusinessLogic.Core
{
    public class UserApi
    {
        internal ULoginResp UserLoginAction(ULoginData data)
        {
            UDBTable user;
            var validate = new EmailAddressAttribute();
            if (validate.IsValid(data.Credentials))
            {
                var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Email == data.Credentials && u.Password == pass);
                }

                if (user == null)
                {
                    return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                using (var todo = new UserContext())
                {
                    user.LastIp = data.LastIp;
                    user.LastLogin = data.LoginDateTime;
                    todo.Entry(user).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new ULoginResp { Status = true };
            }
            else
            {
                var pass = LoginHelper.HashGen(data.Password);
                using (var db = new UserContext())
                {
                    user = db.Users.FirstOrDefault(u => u.Username == data.Credentials && u.Password == pass);
                }

                if (user == null)
                {
                    return new ULoginResp { Status = false, StatusMsg = "The Username or Password is Incorrect" };
                }

                using (var todo = new UserContext())
                {
                    user.LastIp = data.LastIp;
                    user.LastLogin = data.LoginDateTime;
                    todo.Entry(user).State = EntityState.Modified;
                    todo.SaveChanges();
                }

                return new ULoginResp { Status = true };
            }
        }

        internal HttpCookie Cookie(string loginCredential)
        {
            var apiCookie = new HttpCookie("X-KEY")
            {
                Value = CookieGenerator.Create(loginCredential)
            };

            using (var db = new SessionContext())
            {
                Session curent;
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(loginCredential))
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }
                else
                {
                    curent = (from e in db.Sessions where e.Username == loginCredential select e).FirstOrDefault();
                }

                if (curent != null)
                {
                    curent.CookieString = apiCookie.Value;
                    curent.ExpireTime = DateTime.Now.AddMinutes(60);
                    using (var todo = new SessionContext())
                    {
                        todo.Entry(curent).State = EntityState.Modified;
                        todo.SaveChanges();
                    }
                }
                else
                {
                    db.Sessions.Add(new Session
                    {
                        Username = loginCredential,
                        CookieString = apiCookie.Value,
                        ExpireTime = DateTime.Now.AddMinutes(60)
                    });
                    db.SaveChanges();
                }
            }

            return apiCookie;
        }

        internal UserMinimal UserCookie(string cookie)
        {
            Session session;
            UDBTable curentUser;

            using (var db = new SessionContext())
            {
                session = db.Sessions.FirstOrDefault(s => s.CookieString == cookie && s.ExpireTime > DateTime.Now);
            }

            if (session == null) return null;
            using (var db = new UserContext())
            {
                var validate = new EmailAddressAttribute();
                if (validate.IsValid(session.Username))
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Email == session.Username);
                }
                else
                {
                    curentUser = db.Users.FirstOrDefault(u => u.Username == session.Username);
                }
            }

            if (curentUser == null) return null;
            var config = new MapperConfiguration(cfg => cfg.CreateMap<UDBTable, UserMinimal>());
            var mapper = config.CreateMapper();
            var userminimal = mapper.Map<UserMinimal>(curentUser);

            return userminimal;
        }

        internal ULoginResp UserRegisterAction(URegisterData data)
        {
            UDBTable user;

            using (var db = new UserContext())
            {
                user = db.Users.FirstOrDefault(u => u.Username == data.Username);
            }

            // If the user already exists, return an appropriate response
            if (user != null)
            {
                return new ULoginResp { Status = false, StatusMsg = "User already exists" };
            }

            string hashedPassword = LoginHelper.HashGen(data.Password);

            // Create a new user
            user = new UDBTable
            {
                Username = data.Username,
                Password = hashedPassword,
                Email = data.Email,
                Level = URole.User,
                LastIp = URegisterData.GetPublicIpAddress(),
                LastLogin = DateTime.Now
            };

            // Save the new user to the database
            using (var db = new UserContext())
            {
                Database.SetInitializer<UserContext>(new CreateDatabaseIfNotExists<UserContext>());
                db.Users.Add(user);
                db.SaveChanges();
            }

            // Return a successful response
            return new ULoginResp { Status = true, StatusMsg = "User registered successfully" };
        }
    }
}