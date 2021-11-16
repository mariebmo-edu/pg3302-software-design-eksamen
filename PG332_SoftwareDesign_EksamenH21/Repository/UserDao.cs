using Microsoft.EntityFrameworkCore;
using PG332_SoftwareDesign_EksamenH21.Model;

// TODO: Finne ut best practice rundt using. Gir mening at scope kun er i metoden dersom connection lukkes automatisk utenfor scope?
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
            return RetrieveOneByField(u => u.Email == email);
        }

        public User RetrieveByLastName(string lastName)
        {
            return RetrieveOneByField(u => u.LastName == lastName);
        }
    }
}