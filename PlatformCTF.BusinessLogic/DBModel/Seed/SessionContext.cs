using System.Data.Entity;
using PlatformCTF.Domains.Entities.User;

namespace PlatformCTF.BusinessLogic.DBModel
{
    public class SessionContext : DbContext
    {
        public SessionContext() : base("name=CCToolShop")
        {
        }

        public virtual DbSet<Session> Sessions { get; set; }
    }
}