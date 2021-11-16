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
            string email = "kim@bruun.no";
            string password = "daarligpassord";
            auth.UserValid(email, password);
            auth.User = User;
        }

        public string GetFullName()
        {
            return $"{User.FirstName} {User.LastName}";
        }

        public Semester GetCurrentSemester()
        {
            SemesterDao dao = new SemesterDao();
            return dao.RetrieveOneByField(u => u.SemesterEnum == User.CurrentSemester);
        }

        public List<Course> GetCourses()
        {
            CourseDao dao = new CourseDao();
            SemesterDao semesterDao = new SemesterDao();
            long semesterId = semesterDao.GetSemesterIdByUserIdAndSemesterEnum(User.Id, User.CurrentSemester);
            return dao.RetrieveCoursesBySemesterId(semesterId);
        }

        public void SetUser(User user)
        {
            User = user;
        }
    }
}