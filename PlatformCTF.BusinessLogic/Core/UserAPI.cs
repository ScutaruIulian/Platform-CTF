using PlatformCTF.BusinessLogic.DBModel;
using PlatformCTF.Domains.Entities.User;
using PlatformCTF.Domains.Enums;
using System.Linq;

namespace BusinessLogic.Core
{
    public class UserApi
    {
        internal ULoginResp UserLoginAction(ULoginData data)
        {
            UDBTable user;

            using(var db = new UserContext())
            {
                user = db.Users.FirstOrDefault(u => u.Username == data.Credentials);
            }
            using (var db = new UserContext())
            { 
                user = (from u  in db.Users where u.Username == data.Credentials select u).FirstOrDefault();
            }
            if (user == null)
            {
                
            }
            return new ULoginResp();
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

            // Create a new user
            user = new UDBTable
            {
                Username = data.Username,
                Password = data.Password,
                Email = data.Email,
                Level = URole.User,
                LastLogin = data.RegisterDateTime

            };

            // Save the new user to the database
            using (var db = new UserContext())
            {
                db.Users.Add(user);
                db.SaveChanges();
            }

            // Return a successful response
            return new ULoginResp { Status = true, StatusMsg = "User registered successfully" };
        }
    }
}