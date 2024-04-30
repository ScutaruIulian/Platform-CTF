using System.Data.Entity;
using PlatformCTF.Domains.Entities.User;

namespace PlatformCTF.BusinessLogic.DBModel.Seed
{
    public class SessionContext : DbContext
    {
        public SessionContext() : base("name=ULogin")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<SessionContext>());
        }
        public virtual DbSet<Session> Sessions { get; set; }
    }
}