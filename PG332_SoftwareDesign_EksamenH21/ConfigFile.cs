using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;
using static BCrypt.Net.BCrypt;

namespace PG332_SoftwareDesign_EksamenH21
{
    class ConfigFile
    {

        public void AddDummyData()
        {

            UserDao db = new UserDao();
            User user = new();
            Address address = new();
            address.City = "Oslo";
            address.Country = "Norway";
            user.Password = HashPassword("password123");
            Specialization specialization = new();
            //ser.Specialization = specialization;

            user.Address = address;
            user.FirstName = "Roman";
            user.LastName = "Morso";
            //user.Specialization = specialization;
            user.Email = "roman@morso.no";
            user.PhoneNumber = "54892456";
            //user.Specialization = specialization;
            Course course_a = new();
            Course course_b = new();
            Course course_c = new();
            course_a.Semester = SemesterEnum.FIRST;
            course_b.Semester = SemesterEnum.FIRST;
            course_c.Semester = SemesterEnum.FIRST;
            //user.CurrentSemesterId = SemesterEnum.FIRST;
            Semester firstSemester = new();
            Semester secondSemester = new();
            Semester thirdSemester = new();
            Semester fourthSemester = new();
            Semester fifthSemester = new();
            Semester sixthSemester = new();

            user.Semesters = new()
            {
                firstSemester, secondSemester, thirdSemester, fourthSemester, fifthSemester, sixthSemester
            };

            firstSemester.Courses.Add(course_a);
            firstSemester.Courses.Add(course_b);
            firstSemester.Courses.Add(course_c);

                
            Lecture lecture = new();

            course_a.Lectures.Add(lecture);


            //user.StudentCourseOverview = studentCourseOverview;

            Task task_a = new();
            Task task_b = new();
            Task task_c = new();
            lecture.TaskSet.Tasks.Add(task_a);
            lecture.TaskSet.Tasks.Add(task_b);
            lecture.TaskSet.Tasks.Add(task_c);


            db.Save(user);
            
        }
    }
}
