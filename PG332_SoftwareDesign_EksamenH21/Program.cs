using System;
using PG332_SoftwareDesign_EksamenH21.Repository;

namespace PG332_SoftwareDesign_EksamenH21 {
    class Program {
        static void Main(string[] args) {
            Console.WriteLine("Hello World!");
            var lecture = new Lecture();
            var semester = new Semester();
            var course = new Course
            {
                ExamType = ExamType.ORAL
            };

            Task task = new Task
            {
                Lecture = lecture
            };

            semester.Courses.Add(course);
            lecture.TaskSet.Tasks.Add(task);
            course.Lectures.Add(lecture);

            using (var db = new TrackerContext())
            {
                db.Add(semester);
                db.SaveChanges();
            }
        }
    }
}
