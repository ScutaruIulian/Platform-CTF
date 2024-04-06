using PlatformCTF.BusinessLogic.DBModel;
using PlatformCTF.Domains.Entities.User;
using PlatformCTF.Domains.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}