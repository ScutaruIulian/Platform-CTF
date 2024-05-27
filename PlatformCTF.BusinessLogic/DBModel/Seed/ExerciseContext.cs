using System.Data.Entity;
using PlatformCTF.Domains.Entities.User;

namespace PlatformCTF.BusinessLogic.DBModel.Seed
{
    public class ExerciseContext : DbContext
    {
        public ExerciseContext() : base("ULogin")
        {
        }

        public virtual DbSet<Exercise> Exercises { get; set; }
    }
}