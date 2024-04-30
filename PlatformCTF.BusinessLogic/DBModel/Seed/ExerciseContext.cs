using System.Data.Entity;
using PlatformCTF.Domains.Entities.User;

namespace PlatformCTF.BusinessLogic.DBModel.Seed
{
    public class ExerciseContext : DbContext
    {
        public ExerciseContext() : base("name=ULogin")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<ExerciseContext>());
        }
        public virtual DbSet<Exercise> Exercises { get; set; }
    }
}