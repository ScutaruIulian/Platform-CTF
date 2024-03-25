using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformCTF.Domains.EntitiesUser
{
    public class ULoginData
    {
        public string Credentials { get; set; }

        public string Password { get; set; }

        public DateTime LoginDateTime { get; set; }

        public string LoginIp { get; set; }
    }
}
