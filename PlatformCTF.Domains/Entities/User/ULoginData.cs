using PlatformCTF.Domains.Enums;
using System;


namespace PlatformCTF.Domains.Entities.User
{
    public class ULoginData
    {
        public string Credentials { get; set; }
        public string Password { get; set; }
        public string LoginIp { get; set; }
        public DateTime LoginDateTime { get; set; }
    }
}
