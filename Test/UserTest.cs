using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PG332_SoftwareDesign_EksamenH21;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;
using Task = PG332_SoftwareDesign_EksamenH21.Task;

namespace Test
{
    class UserTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void SaveUserAndAggregatedClassesTest()
        {


            var task_A = new Task();
            var task_B = new Task();
            var task_C = new Task();

            var lecture = new Lecture();
            lecture.TaskSet.Tasks.Add(task_A);
            var course = new Course();
            course.Lectures.Add(lecture);


            Specialization specialization = new Specialization();
            User user = new()
            {
                Specialization = specialization
            };
            
            using (var db = new TrackerContext())
            {

                db.Add(user);
                db.SaveChanges();


                User userFromServer = db.Users
                    .OrderByDescending(s => s.Id)
                    .First();
                Console.WriteLine($"Semester id: {user.Id}");
                Console.WriteLine($"Semester from server id: {userFromServer.Id}");

                Assert.AreEqual(user, userFromServer);
            }


        }

        public void RetrieveUserFromDB()
        {
            using (var db = new TrackerContext())
            {
                Console.WriteLine($"Database path: { db.DbPath}");

                var user = db.Users
                    .Find(1);

                Assert.AreEqual(1, user.Id);

                Console.WriteLine($"User: {user.ToString()}");
            }


        }

    }
}
