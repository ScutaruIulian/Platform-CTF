using PlatformCTF.BusinessLogic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformCTF.BusinessLogic
{
    public class SessionBL : ISession
    {
        public bool UserLogin(ULoginData uloginData)
        {
            throw new NotImplementedException();
        }

        public bool UserLogin(UloginData uloginData)
        {
            throw new NotImplementedException();
        }
    }
}
