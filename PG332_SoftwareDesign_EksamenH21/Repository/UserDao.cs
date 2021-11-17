using System.Linq;
using Microsoft.EntityFrameworkCore;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Repository
{
    public class UserDao : AbstractDao<User>, IUserDao
    {
        protected override DbSet<User> RetrieveDbSet(TrackerContext trackerContext)
        {
            return trackerContext.Users;
        }

        public User RetrieveByEmail(string email)
        {
            using TrackerContext trackerContext = new();
            return trackerContext.Users
                .Include(user => user.Semesters)
                .Include(user => user.Address)
                .FirstOrDefault(u => u.Email.Equals(email));
        }

        public User RetrieveByLastName(string lastName)
        {
            return RetrieveOneByField(u => u.LastName == lastName);
        }
    }
}