using PlatformCTF.Domains.Entities.User;
using System.Data.Entity;

namespace PlatformCTF.BusinessLogic.DBModel
{
    public class UserContext : DbContext
    {
        public UserContext() : base ("ULogin")
        {
        }
        public virtual DbSet<UDBTable> Users { get; set; }
    }
}

