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
            User user = trackerContext.Users
                .Include(user => user.Address)
                .Include(user => user.Semesters)
                .ThenInclude(semester => semester.Courses.OrderBy(s => s.SemesterEnum))
                .ThenInclude(course => course.Lectures.OrderBy(l => l.Title))
                .ThenInclude(lecture => lecture.TaskSet)
                .ThenInclude(taskSet => taskSet.Tasks.OrderBy(t => t.Title))
                .FirstOrDefault(u => u.Email.Equals(email));

            return user;
        }

        public User RetrieveByLastName(string lastName)
        {
            return RetrieveOneByField(u => u.LastName == lastName);
        }
    }
}