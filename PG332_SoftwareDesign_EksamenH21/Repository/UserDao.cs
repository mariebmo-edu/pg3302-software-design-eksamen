using System;
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
                .ThenInclude(course => course.Lectures)
                .ThenInclude(lecture => lecture.TaskSet)
                .ThenInclude(taskSet => taskSet.Tasks.OrderBy(t => t.Title))
                .FirstOrDefault(u => u.Email.Equals(email));
            if (user != null)
            {
                SortLectures(user);
            }
            return user;
        }

        private static void SortLectures(User user)
        {
            foreach (var semester in user.Semesters)
            {
                foreach (var course in semester.Courses)
                {
                    course.Lectures.Sort((a, b) => Int32.Parse(a.Title.Split(" ")[1])
                        .CompareTo(Int32.Parse(b.Title.Split(" ")[1])));
                }
            }
        }

        public User RetrieveByLastName(string lastName)
        {
            return RetrieveOneByField(u => u.LastName == lastName);
        }
    }
}
