using PlatformCTF.Domains.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlatformCTF.Domains.Entities.User
{
    public class URegisterData
    {
        public string Username { get; set; }
        public string Email { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Password { get; set; }

        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set;}

        public DateTime RegisterDateTime { get; set; }
        public URole Level { get; set; }
    }
}
