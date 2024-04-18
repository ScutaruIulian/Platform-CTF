using PlatformCTF.Domains.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace PlatformCTF.Domains.Entities.User
{
    public class ULoginData
    {
        
        public string Credentials { get; set; }
        public string Password { get; set; }
        public string LastIp { get; set; }
        //specifie the data type of column in database
        [Column(TypeName = "datetime2")]
        public DateTime LoginDateTime { get; set; }
        
        
    }
}
