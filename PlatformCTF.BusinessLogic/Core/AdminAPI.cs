using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PlatformCTF.Domains.Entities.User;
using PlatformCTF.BusinessLogic.Interfaces;
using PlatformCTF.Domain.Entities.User;

namespace PlatformCTF.BusinessLogic.Core
{
    public class AdminAPI
    {
        private readonly ISession _session;

        public AdminAPI(ISession session)
        {
            _session = session;
        }

        public void AddExerciseToCategory(string category, string exercise)
        {
            // Logic to add exercise to the specified category
            // This will depend on how your categories and exercises are structured in your database
        }

        public List<UserMinimal> GetAllLoggedUsers()
        {
            // Logic to get all logged users
            // This will depend on how you track logged in users in your application
            return new List<UserMinimal>();
        }

        public void BanUser(string username)
        {
            // Logic to ban a user
            // This will depend on how you manage users in your application
        }
    }
}