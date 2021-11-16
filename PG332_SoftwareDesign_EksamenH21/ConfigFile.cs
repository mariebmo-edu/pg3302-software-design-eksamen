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

            //SPECIALIZATION
            SpecializationDao specializationDao = new();
            Specialization specialization = new();

            specialization.Name = "Programmering";
            specialization.Code = "pgr2020";

            specializationDao.Save( specialization );



            //COURSES
            CourseDao courseDao = new();

            //first semester
            Course tk1104 = new();
            tk1104.CourseCode = "tk1104";
            tk1104.CoursePoints = 7.5F;
            tk1104.ExamType = ExamType.HOME_24_HR;
            tk1104.ExamDate = new DateTime( 2020, 12, 15 );
            tk1104.Semester = SemesterEnum.FIRST;

            Course db1102 = new();
            db1102.CourseCode = "db1102";
            db1102.CoursePoints = 7.5F;
            db1102.ExamType = ExamType.HOME_24_HR;
            db1102.ExamDate = new DateTime( 2020, 12, 1 );
            db1102.Semester = SemesterEnum.FIRST;

            Course pgr102 = new();
            pgr102.CourseCode = "pgr102";
            pgr102.CoursePoints = 7.5F;
            pgr102.ExamType = ExamType.HOME_24_HR;
            pgr102.ExamDate = new DateTime( 2020, 12, 8 );
            pgr102.Semester = SemesterEnum.FIRST;

            Course pro105 = new();
            pro105.CourseCode = "pro105";
            pro105.CoursePoints = 7.5F;
            pro105.ExamType = ExamType.PROJECT;
            pro105.ExamDate = new DateTime( 2020, 11, 9 );
            pro105.Semester = SemesterEnum.FIRST;


            //second semester
            Course pgr103 = new();
            pgr103.CourseCode = "pgr103";
            pgr103.CoursePoints = 7.5F;
            pgr103.ExamType = ExamType.HOME_24_HR;
            pgr103.ExamDate = new DateTime( 2021, 4, 29 );
            pgr103.Semester = SemesterEnum.SECOND;

            Course tk2100 = new();
            tk2100.CourseCode = "tk2100";
            tk2100.CoursePoints = 7.5F;
            tk2100.ExamType = ExamType.HOME_24_HR;
            tk2100.ExamDate = new DateTime( 2021, 5, 6 );
            tk2100.Semester = SemesterEnum.SECOND;

            Course pro104 = new();
            pro104.CourseCode = "pro104";
            pro104.CoursePoints = 7.5F;
            pro104.ExamType = ExamType.PROJECT;
            pro104.ExamDate = new DateTime( 2021, 5, 18 );
            pro104.Semester = SemesterEnum.SECOND;

            Course pg2201 = new();
            pg2201.CourseCode = "pg2201";
            pg2201.CoursePoints = 7.5F;
            pg2201.ExamType = ExamType.PROJECT;
            pg2201.ExamDate = new DateTime( 2021, 4, 23 );
            pg2201.Semester = SemesterEnum.SECOND;


            //third semester
            Course pg3302 = new();
            pg3302.CourseCode = "pg3302";
            pg3302.CoursePoints = 7.5F;
            pg3302.ExamType = ExamType.PROJECT;
            pg3302.ExamDate = new DateTime( 2021, 11, 19 );
            pg3302.Semester = SemesterEnum.THIRD;

            Course pg4200 = new();
            pg4200.CourseCode = "pg4200";
            pg4200.CoursePoints = 7.5F;
            pg4200.ExamType = ExamType.HOME_24_HR;
            pg4200.ExamDate = new DateTime( 2021, 11, 25 );
            pg4200.Semester = SemesterEnum.THIRD;

            Course pgr203 = new();
            pgr203.CourseCode = "pgr203";
            pgr203.CoursePoints = 7.5F;
            pgr203.ExamType = ExamType.PROJECT;
            pgr203.ExamDate = new DateTime( 2021, 11, 15 );
            pgr203.Semester = SemesterEnum.THIRD;

            Course pro201_autumn = new();
            pro201_autumn.CourseCode = "pro201";
            pro201_autumn.CoursePoints = 0;
            pro201_autumn.Semester = SemesterEnum.THIRD;


            //fourth semester
            Course pro201_spring = new();
            pro201_spring.CourseCode = "pro201";
            pro201_spring.CoursePoints = 15;
            pro201_spring.ExamType = ExamType.PROJECT;
            pro201_spring.ExamDate = new DateTime( 2022, 5, 29 );
            pro201_spring.Semester = SemesterEnum.FOURTH;

            Course pg6301 = new();
            pg6301.CourseCode = "pg6301";
            pg6301.CoursePoints = 7.5F;
            pg6301.ExamType = ExamType.HOME_48_HR;
            pg6301.ExamDate = new DateTime( 2022, 4, 20 );
            pg6301.Semester = SemesterEnum.FOURTH;

            Course pgr208 = new();
            pgr208.CourseCode = "pgr208";
            pgr208.CoursePoints = 7.5F;
            pgr208.ExamType = ExamType.PROJECT;
            pgr208.ExamDate = new DateTime( 2022, 4, 16 );
            pgr208.Semester = SemesterEnum.FOURTH;

            Course pg5100 = new();
            pg5100.CourseCode = "pg5100";
            pg5100.CoursePoints = 7.5F;
            pg5100.ExamType = ExamType.HOME_48_HR;
            pg5100.ExamDate = new DateTime( 2022, 4, 8 );
            pg5100.Semester = SemesterEnum.FOURTH;


            //fifth semester
            Course pg6102 = new();
            pg6102.CourseCode = "pg6102";
            pg6102.CoursePoints = 7.5F;
            pg6102.ExamType = ExamType.HOME_48_HR;
            pg6102.ExamDate = new DateTime( 2022, 11, 29 );
            pg6102.Semester = SemesterEnum.FIFTH;

            Course pgr301 = new();
            pgr301.CourseCode = "pgr301";
            pgr301.CoursePoints = 7.5F;
            pgr301.ExamType = ExamType.PROJECT;
            pgr301.ExamDate = new DateTime( 2022, 11, 1 );
            pgr301.Semester = SemesterEnum.FIFTH;

            Course pg3401 = new();
            pg3401.CourseCode = "pg3401";
            pg3401.CoursePoints = 7.5F;
            pg3401.ExamType = ExamType.PROJECT;
            pg3401.ExamDate = new DateTime( 2022, 12, 1 );
            pg3401.Semester = SemesterEnum.FIFTH;

            Course pg5501 = new();
            pg5501.CourseCode = "pg5501";
            pg5501.CoursePoints = 7.5F;
            pg5501.ExamType = ExamType.PROJECT;
            pg5501.ExamDate = new DateTime(2022, 12, 7);
            pg5501.Semester = SemesterEnum.FIFTH;

            //sixth semester
            Course bao302 = new();
            bao302.CourseCode = "bao302";
            bao302.CoursePoints = 22.5F;
            bao302.ExamType = ExamType.PROJECT;
            bao302.ExamDate = new DateTime( 2023, 1, 1 );
            bao302.Semester = SemesterEnum.SIXTH;

            Course pj6100 = new();
            pj6100.CourseCode = "bao302";
            pj6100.CoursePoints = 7.5F;
            pj6100.ExamType = ExamType.PROJECT;
            pj6100.ExamDate = new DateTime( 2023, 4, 2 );
            pj6100.Semester = SemesterEnum.SIXTH;

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
            user.Password = HashPassword( "daarligpassord" );
            user.PhoneNumber = "12378094";
            user.CurrentSemester = SemesterEnum.THIRD;

            Semester firstSemester = new();
            Semester secondSemester = new();
            Semester thirdSemester = new();
            Semester fourthSemester = new();
            Semester fifthSemester = new();
            Semester sixthSemester = new();

            firstSemester.Courses.Add( tk1104 );
            firstSemester.Courses.Add( db1102 );
            firstSemester.Courses.Add( pgr102 );
            firstSemester.Courses.Add( pro105 );
            firstSemester.SemesterEnum = SemesterEnum.FIRST;
            
            secondSemester.Courses.Add( pgr103 );
            secondSemester.Courses.Add( tk2100 );
            secondSemester.Courses.Add( pro104 );
            secondSemester.Courses.Add( pg2201 );
            secondSemester.SemesterEnum = SemesterEnum.SECOND;
            
            thirdSemester.Courses.Add( pg3302 );
            thirdSemester.Courses.Add( pg4200 );
            thirdSemester.Courses.Add( pgr203 );
            thirdSemester.Courses.Add( pro201_autumn );
            thirdSemester.SemesterEnum = SemesterEnum.THIRD;
            
            fourthSemester.Courses.Add( pro201_spring );
            fourthSemester.Courses.Add( pg6301 );
            fourthSemester.Courses.Add( pgr208 );
            fourthSemester.Courses.Add( pg5100 );
            fourthSemester.SemesterEnum = SemesterEnum.FOURTH;
            
            fifthSemester.Courses.Add( pg6102 );
            fifthSemester.Courses.Add( pgr301 );
            fifthSemester.Courses.Add( pg3401 );
            fifthSemester.Courses.Add( pg5501 );
            fifthSemester.SemesterEnum = SemesterEnum.FIFTH;
            
            sixthSemester.Courses.Add( bao302 );
            sixthSemester.Courses.Add( pj6100 );
            sixthSemester.SemesterEnum = SemesterEnum.SIXTH;
            
            user.Semesters = new() { 
                firstSemester, secondSemester, thirdSemester, fourthSemester, fifthSemester, sixthSemester
            };

            AddCourseData( new Semester[] { firstSemester, secondSemester, thirdSemester } );

            /*
            Lecture lecture = new();
            pg3302.Lectures.Add( lecture );

            Task mission_1 = new();
            mission_1.Description = "Hva er S i Solid?";

            Task mission_2 = new();
            mission_2.Description = "Hva er facade (designpattern)?";

            Task mission_3 = new();
            mission_3.Description = "Hva er C#, og hvordan kom den seg til Visual Studio?";

            lecture.TaskSet.Tasks.Add( mission_1 );
            lecture.TaskSet.Tasks.Add( mission_2 );
            lecture.TaskSet.Tasks.Add( mission_3 );

            UserDao db = new UserDao();
            User user = new();
            Address address = new();
            address.City = "Oslo";
            address.Country = "Norway";

            user.password = HashPassword("password123");
            //user.Specialization = specialization;

            user.Address = address;
            user.FirstName = "Kim";
            user.LastName = "Possible";

            //user.Specialization = specialization;
            user.Email = "kom@possible.no";
            user.PhoneNumber = "12365432";

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
            */

        }

        void AddCourseData(Semester[] semesters) {
            foreach(Semester s in semesters){
                foreach(Course c in s.Courses) {

                    Random random = new();
                    int lectureAmount = random.Next( 12 );

                    for(int i = 0; i < lectureAmount; i++) {
                        Lecture lecture = new();
                        lecture.Title = RandomTitle();
                        c.Lectures.Add( lecture );
                        int taskAmount = random.Next( 5 );

                        for(int j=0; j<taskAmount; j++) {
                            Task task = new();
                            task.Description = RandomDescription();
                            c.Lectures[i].TaskSet.Tasks.Add( task );
                        }


                    }
                }
            }
        }

        string RandomTitle() {
            string[] titles = { "Fantastic Beasts and where to find them", "Hvor mye veier en hvalross", "Hvor mye tjente egentlig Monica i Friends?" };

            Random random = new();

            return titles[random.Next( titles.Length-1 )];
        }

        string RandomDescription() {
            string[] descriptions = {"Skriv åtte sider om hvor mye du liker ost", "Hvis en appelsin bodde på månen, og Bush var president, hvor lang ville en linjal på 32 cm vært i juni?"};
            Random random = new();

            return descriptions[random.Next( descriptions.Length - 1 )];
        }
    }
}
