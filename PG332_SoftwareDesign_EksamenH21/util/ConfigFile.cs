using System;
using System.IO;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;
using static BCrypt.Net.BCrypt;

namespace PG332_SoftwareDesign_EksamenH21
{
    class ConfigFile
    {
        public static string programFilesDir =
            $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}{Path.DirectorySeparatorChar}";

        public void AddDummyData()
        {
            clearDataFromDb();


            //first semester
            Course tk1104 = new();
            tk1104.CourseCode = "tk1104";
            tk1104.CoursePoints = 7.5F;
            tk1104.ExamType = ExamType.HOME_24_HR;
            tk1104.ExamDate = new DateTime(2020, 12, 15);
            tk1104.SemesterEnum = SemesterEnum.FIRST;

            Course db1102 = new();
            db1102.CourseCode = "db1102";
            db1102.CoursePoints = 7.5F;
            db1102.ExamType = ExamType.HOME_24_HR;
            db1102.ExamDate = new DateTime(2020, 12, 1);
            db1102.SemesterEnum = SemesterEnum.FIRST;

            Course pgr102 = new();
            pgr102.CourseCode = "pgr102";
            pgr102.CoursePoints = 7.5F;
            pgr102.ExamType = ExamType.HOME_24_HR;
            pgr102.ExamDate = new DateTime(2020, 12, 8);
            pgr102.SemesterEnum = SemesterEnum.FIRST;

            Course pro105 = new();
            pro105.CourseCode = "pro105";
            pro105.CoursePoints = 7.5F;
            pro105.ExamType = ExamType.PROJECT;
            pro105.ExamDate = new DateTime(2020, 11, 9);
            pro105.SemesterEnum = SemesterEnum.FIRST;


            //second semester
            Course pgr103 = new();
            pgr103.CourseCode = "pgr103";
            pgr103.CoursePoints = 7.5F;
            pgr103.ExamType = ExamType.HOME_24_HR;
            pgr103.ExamDate = new DateTime(2021, 4, 29);
            pgr103.SemesterEnum = SemesterEnum.SECOND;

            Course tk2100 = new();
            tk2100.CourseCode = "tk2100";
            tk2100.CoursePoints = 7.5F;
            tk2100.ExamType = ExamType.HOME_24_HR;
            tk2100.ExamDate = new DateTime(2021, 5, 6);
            tk2100.SemesterEnum = SemesterEnum.SECOND;

            Course pro104 = new();
            pro104.CourseCode = "pro104";
            pro104.CoursePoints = 7.5F;
            pro104.ExamType = ExamType.PROJECT;
            pro104.ExamDate = new DateTime(2021, 5, 18);
            pro104.SemesterEnum = SemesterEnum.SECOND;

            Course pg2201 = new();
            pg2201.CourseCode = "pg2201";
            pg2201.CoursePoints = 7.5F;
            pg2201.ExamType = ExamType.PROJECT;
            pg2201.ExamDate = new DateTime(2021, 4, 23);
            pg2201.SemesterEnum = SemesterEnum.SECOND;


            //third semester
            Course pg3302 = new();
            pg3302.CourseCode = "pg3302";
            pg3302.CoursePoints = 7.5F;
            pg3302.ExamType = ExamType.PROJECT;
            pg3302.ExamDate = new DateTime(2021, 11, 19);
            pg3302.SemesterEnum = SemesterEnum.THIRD;

            Course pg4200 = new();
            pg4200.CourseCode = "pg4200";
            pg4200.CoursePoints = 7.5F;
            pg4200.ExamType = ExamType.HOME_24_HR;
            pg4200.ExamDate = new DateTime(2021, 11, 25);
            pg4200.SemesterEnum = SemesterEnum.THIRD;

            Course pgr203 = new();
            pgr203.CourseCode = "pgr203";
            pgr203.CoursePoints = 7.5F;
            pgr203.ExamType = ExamType.PROJECT;
            pgr203.ExamDate = new DateTime(2021, 11, 15);
            pgr203.SemesterEnum = SemesterEnum.THIRD;

            Course pro201_autumn = new();
            pro201_autumn.CourseCode = "pro201";
            pro201_autumn.CoursePoints = 0;
            pro201_autumn.SemesterEnum = SemesterEnum.THIRD;


            //fourth semester
            Course pro201_spring = new();
            pro201_spring.CourseCode = "pro201";
            pro201_spring.CoursePoints = 15;
            pro201_spring.ExamType = ExamType.PROJECT;
            pro201_spring.ExamDate = new DateTime(2022, 5, 29);
            pro201_spring.SemesterEnum = SemesterEnum.FOURTH;

            Course pg6301 = new();
            pg6301.CourseCode = "pg6301";
            pg6301.CoursePoints = 7.5F;
            pg6301.ExamType = ExamType.HOME_48_HR;
            pg6301.ExamDate = new DateTime(2022, 4, 20);
            pg6301.SemesterEnum = SemesterEnum.FOURTH;

            Course pgr208 = new();
            pgr208.CourseCode = "pgr208";
            pgr208.CoursePoints = 7.5F;
            pgr208.ExamType = ExamType.PROJECT;
            pgr208.ExamDate = new DateTime(2022, 4, 16);
            pgr208.SemesterEnum = SemesterEnum.FOURTH;

            Course pg5100 = new();
            pg5100.CourseCode = "pg5100";
            pg5100.CoursePoints = 7.5F;
            pg5100.ExamType = ExamType.HOME_48_HR;
            pg5100.ExamDate = new DateTime(2022, 4, 8);
            pg5100.SemesterEnum = SemesterEnum.FOURTH;


            //fifth semester
            Course pg6102 = new();
            pg6102.CourseCode = "pg6102";
            pg6102.CoursePoints = 7.5F;
            pg6102.ExamType = ExamType.HOME_48_HR;
            pg6102.ExamDate = new DateTime(2022, 11, 29);
            pg6102.SemesterEnum = SemesterEnum.FIFTH;

            Course pgr301 = new();
            pgr301.CourseCode = "pgr301";
            pgr301.CoursePoints = 7.5F;
            pgr301.ExamType = ExamType.PROJECT;
            pgr301.ExamDate = new DateTime(2022, 11, 1);
            pgr301.SemesterEnum = SemesterEnum.FIFTH;

            Course pg3401 = new();
            pg3401.CourseCode = "pg3401";
            pg3401.CoursePoints = 7.5F;
            pg3401.ExamType = ExamType.PROJECT;
            pg3401.ExamDate = new DateTime(2022, 12, 1);
            pg3401.SemesterEnum = SemesterEnum.FIFTH;

            Course pg5501 = new();
            pg5501.CourseCode = "pg5501";
            pg5501.CoursePoints = 7.5F;
            pg5501.ExamType = ExamType.PROJECT;
            pg5501.ExamDate = new DateTime(2022, 12, 7);
            pg5501.SemesterEnum = SemesterEnum.FIFTH;

            //sixth semester
            Course bao302 = new();
            bao302.CourseCode = "bao302";
            bao302.CoursePoints = 22.5F;
            bao302.ExamType = ExamType.PROJECT;
            bao302.ExamDate = new DateTime(2023, 1, 1);
            bao302.SemesterEnum = SemesterEnum.SIXTH;

            Course pj6100 = new();
            pj6100.CourseCode = "pj6100";
            pj6100.CoursePoints = 7.5F;
            pj6100.ExamType = ExamType.PROJECT;
            pj6100.ExamDate = new DateTime(2023, 4, 2);
            pj6100.SemesterEnum = SemesterEnum.SIXTH;

            //USER
            UserDao userDao = new UserDao();
            User user = new();

            Address address = new();

            address.City = "Oslo";
            address.Country = "Norway";
            address.Street = "Osloveien";
            address.StreetNumber = "1";
            address.PostalCode = "0000";

            user.Address = address;
            user.FirstName = "Kim";
            user.LastName = "Bruun";
            user.Password = HashPassword("daarligpassord");
            user.Email = "kim@bruun.no";
            user.PhoneNumber = "12378094";
            user.CurrentSemester = SemesterEnum.THIRD;

            Semester firstSemester = new()
            {
                User = user
            };
            Semester secondSemester = new()
            {
                User = user
            };
            Semester thirdSemester = new()
            {
                User = user
            };
            Semester fourthSemester = new()
            {
                User = user
            };
            Semester fifthSemester = new()
            {
                User = user
            };
            Semester sixthSemester = new()
            {
                User = user
            };

            firstSemester.Courses = new();
            firstSemester.Courses.Add(tk1104);
            firstSemester.Courses.Add(db1102);
            firstSemester.Courses.Add(pgr102);
            firstSemester.Courses.Add(pro105);

            firstSemester.SemesterEnum = SemesterEnum.FIRST;

            secondSemester.Courses = new();
            secondSemester.Courses.Add(pgr103);
            secondSemester.Courses.Add(tk2100);
            secondSemester.Courses.Add(pro104);
            secondSemester.Courses.Add(pg2201);
            secondSemester.SemesterEnum = SemesterEnum.SECOND;

            thirdSemester.Courses = new();
            thirdSemester.Courses.Add(pg3302);
            thirdSemester.Courses.Add(pg4200);
            thirdSemester.Courses.Add(pgr203);
            thirdSemester.Courses.Add(pro201_autumn);
            thirdSemester.SemesterEnum = SemesterEnum.THIRD;

            fourthSemester.Courses = new();
            fourthSemester.Courses.Add(pro201_spring);
            fourthSemester.Courses.Add(pg6301);
            fourthSemester.Courses.Add(pgr208);
            fourthSemester.Courses.Add(pg5100);
            fourthSemester.SemesterEnum = SemesterEnum.FOURTH;

            fifthSemester.Courses = new();
            fifthSemester.Courses.Add(pg6102);
            fifthSemester.Courses.Add(pgr301);
            fifthSemester.Courses.Add(pg3401);
            fifthSemester.Courses.Add(pg5501);
            fifthSemester.SemesterEnum = SemesterEnum.FIFTH;

            sixthSemester.Courses = new();
            sixthSemester.Courses.Add(bao302);
            sixthSemester.Courses.Add(pj6100);
            sixthSemester.SemesterEnum = SemesterEnum.SIXTH;

            user.Semesters = new()
            {
                firstSemester, secondSemester, thirdSemester, fourthSemester, fifthSemester, sixthSemester
            };

            AddCourseData(new Semester[] {firstSemester, secondSemester, thirdSemester});

            userDao.Save(user);
        }

        private void clearDataFromDb()
        {
            using TrackerContext trackerContext = new();
            trackerContext.Courses.RemoveRange(trackerContext.Courses);
            trackerContext.Lectures.RemoveRange(trackerContext.Lectures);
            trackerContext.Semesters.RemoveRange(trackerContext.Semesters);
            trackerContext.Tasks.RemoveRange(trackerContext.Tasks);
            trackerContext.TaskSets.RemoveRange(trackerContext.TaskSets);
            trackerContext.Users.RemoveRange(trackerContext.Users);
            trackerContext.Addresses.RemoveRange(trackerContext.Addresses);
            trackerContext.SaveChanges();
        }


        void AddCourseData(Semester[] semesters)
        {
            foreach (Semester s in semesters)
            {
                foreach (Course c in s.Courses)
                {
                    Random random = new();
                    int lectureAmount = random.Next(12);
                    c.Lectures = new();
                    for (int i = 0; i < lectureAmount; i++)
                    {
                        Lecture lecture = new();
                        lecture.Title = "Forelesning " + (i + 1);
                        lecture.Finished = randomBool();
                        c.Lectures.Add(lecture);
                        int taskAmount = random.Next(5);
                        c.Lectures[i].TaskSet = new();
                        c.Lectures[i].TaskSet.Tasks = new();
                        for (int j = 0; j < taskAmount; j++)
                        {
                            Task task = new();
                            task.Title = "Mission " + (j + 1);
                            task.Finished = randomBool();
                            task.Description = RandomDescription();
                            c.Lectures[i].TaskSet.Tasks.Add(task);
                        }
                    }
                }
            }
        }

        private bool randomBool()
        {
            Random nextInt = new Random();

            return nextInt.Next(2) == 1;
        }

        string RandomTitle()
        {
            string[] titles =
            {
                "Fantastic Beasts and where to find them", "Hvor mye veier en hvalross",
                "Hvor mye tjente egentlig Monica i Friends?"
            };

            Random random = new();

            return titles[random.Next(titles.Length)];
        }

        string RandomDescription()
        {
            string[] descriptions =
            {
                "Skriv åtte sider om hvor mye du liker ost",
                "Hvis en appelsin bodde på månen, og Bush var president, hvor lang ville en linjal på 32 cm vært i juni?"
            };
            Random random = new();

            return descriptions[random.Next(descriptions.Length)];
        }
    }
}