using System.Data.Entity;
using PlatformCTF.Domains.Entities.User;

namespace PlatformCTF.BusinessLogic.DBModel.Seed
{
    public class SessionContext : DbContext
    {
        public SessionContext() : base("ULogin")
        {
        }

        public virtual DbSet<Session> Sessions { get; set; }
    }
}