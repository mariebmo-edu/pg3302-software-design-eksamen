using System;
using System.Linq;
using NUnit.Framework;
using PG332_SoftwareDesign_EksamenH21;
using PG332_SoftwareDesign_EksamenH21.Repository;

namespace Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ShouldSaveSemesterToServer()
        {

            var task_A = new Task();
            var task_B = new Task();
            var task_C = new Task();

            var lecture = new Lecture();
            lecture.TaskSet.Tasks.Add(task_A);
            //lecture.TaskSet.Tasks.Add(task_B);
            //lecture.TaskSet.Tasks.Add(task_C);

            var course = new Course();
            course.Lectures.Add(lecture);

            var semester = new Semester();
            semester.Courses.Add(course);

            using (var db = new TrackerContext())
            {
                Console.WriteLine($"Database path: { db.DbPath}");
                db.Add(semester);
                db.SaveChanges();


                Semester semesterFromServer = db.Semesters
                    .OrderByDescending(s => s.Id)
                    .First();
                Console.WriteLine($"Semester id: {semester.Id}");
                Console.WriteLine($"Semester from server id: {semesterFromServer.Id}");

                Assert.AreEqual(semester,semesterFromServer);
            }
            
        }
    }
}