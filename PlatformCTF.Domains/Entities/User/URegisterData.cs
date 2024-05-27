using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using PlatformCTF.Domains.Enums;

namespace PlatformCTF.Domains.Entities.User
{
    public class URegisterData
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string IpAddress { get; set; }

        public DateTime RegisterDateTime { get; set; }

        public URole Level { get; set; }
    }
}