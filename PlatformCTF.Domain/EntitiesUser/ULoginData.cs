using System;

namespace Domain.Entities.User
{
    public class ULoginData
    {
        public string Credentials { get; set; }

        public string Password { get; set; }

        public DateTime LoginDateTime { get; set; }

        public string LoginIp { get; set; }
    }
}