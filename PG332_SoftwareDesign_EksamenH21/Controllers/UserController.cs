using System.Collections.Generic;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;

namespace PG332_SoftwareDesign_EksamenH21.Controllers
{
    public class UserController
    {
        private User User;

        public void Authenticate()
        {
            UserAuthenticator auth = new UserAuthenticator(this); 
            string email = "roman@morso.no";
            string password = "password123";
            auth.UserValid(email, password);
            auth.User = User;
        }

        public string GetFullName()
        {
            return $"{User.FirstName} {User.LastName}";
        }

        public List<Semester> GetSemesters()
        {
            SemesterDao dao = new SemesterDao();
            return dao.RetrieveUserSemesters(User);
        }

        public List<Course> GetCourses()
        {
            CourseDao dao = new CourseDao();
            return null;
        }

        public void SetUser(User user)
        {
            User = user;
        }

        public SemesterEnum GetCurrentSemester()
        {
            return User.CurrentSemester;
        }
    }
}