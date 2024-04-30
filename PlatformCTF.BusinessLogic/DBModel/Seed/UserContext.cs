using System.Data.Entity;
using PlatformCTF.Domains.Entities.User;

namespace PlatformCTF.BusinessLogic.DBModel.Seed
{
    public class UserContext : DbContext
    {
        public UserContext() : base ("name=ULogin")
        { 
            Database.SetInitializer(new CreateDatabaseIfNotExists<UserContext>());
        }
        public virtual DbSet<UDBTable> Users { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
    }
}