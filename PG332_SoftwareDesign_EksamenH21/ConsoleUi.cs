using System;
using System.Collections.Generic;
using PG332_SoftwareDesign_EksamenH21.Controllers;
using PG332_SoftwareDesign_EksamenH21.Handlers;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;
using PG332_SoftwareDesign_EksamenH21.util;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class ConsoleUi : IConsoleUi
    {
        public UserController UserController { get; private set; }
        public User User { get; set; }
        public bool IsLoggedIn { get; set; } = false;
        public MenuPrinter<IProgressable> MenuPrinter { get; set; } = new(); // needs refactoring

        public void SetUserController(UserController controller)
        {
            UserController = controller;
        }
        public void UserLoginMenu()
        {
            UserAuthenticator userAuthenticator = new UserAuthenticator(UserController);
         
            string loginPresentation = "*** Login ***\r\n";
            PrintMessage(loginPresentation);

            while (!IsLoggedIn)
            {
                PrintMessage("Please enter your email address");
                String email = "kim@bruun.no";
                String password = "12378094";
                //string email = ConsoleRead();
                PrintMessage("Please enter your password");
                //string password = ConsoleRead();
                
                IsLoggedIn = userAuthenticator.UserValid(email, password);
            }

            User = userAuthenticator.User;
            SemesterDao semesterDao = new();

            List<Semester> semesters = semesterDao.ListAll();
            semesters.Sort((a, b) => a.Id.CompareTo(b.Id));

            User.Semesters = semesters;
        }
        
        public void start()
        {

            UserController.Authenticate();
            // Email = "gMail@email.no", password = HashPassword("password123")};
            

            string fullName = UserController.GetFullName();
            while (true)
            {
                // MenuPrinter.ShowMenu(OptionsHandlerFactory.MakeOptionsHandler(User, null));
                
                ShowMainMenu(fullName);
                switch (ConsoleRead())
                {
                    case "1":
                        ShowCourseMenu(1);
                        break;
                    case "2":
                        ShowCourseMenu(2);
                        break;
                    case "3":
                        ShowCourseMenu(3);
                        break;
                    case "4":
                        ShowCourseMenu(4);
                        break;
                    case "0":
                        PrintMessage("gå til spesialiseringsmeny");
                        break;
                    case "E":
                        PrintMessage("Du har valgt avslutt");
                        ShowSelectSpecializationMenu();
                        break;
                    default:
                        PrintMessage("Ugyldig valg");
                        break;
                }
                
            }
        }

        public void ShowMainMenu(string fullName)
        {
            //string name = "Harry";
            Semester semester = UserController.GetCurrentSemester();
            ProgressionHandlerComposite semesterHandler = new(semester);

            ProgressionWrapper progWrap = semesterHandler.GetProgression();

            string progressionBar = ProgressionBarHandler.GenerateProgressBar(progWrap);
            string mainMenuPresentation = $"Velkommen, {fullName}\r\n" +
                                          $"Nåværende semester: {semester}\r\n" +
                                          $"{progressionBar}\r\n" +
                                          "\r\n" +
                                          "Velg emne:\r\n";
            
            var courses = UserController.GetCourses();
            
            for (int i = 0; i < courses.Count; i++)
            {
                mainMenuPresentation += $"{i + 1} - {courses[i]}\r\n";
            }
            mainMenuPresentation += "0 - gå til spesialiseringsmeny\r\n" +
                                    "\r\n" +
                                        "E - avslutt\r\n";
            PrintMessage(mainMenuPresentation);
        }

        public void ShowCourseMenu(int courseIndex)
        {
            string courseName = "AdvJava";
            List<Lecture> lectures = new List<Lecture>()
            {
                new()
                {
                    Title = "Lecture1"
                }
            };

            string lecturePresentation = "";

            for (int i = 0; i < lectures.Count; i++)
            {
                lecturePresentation += $"{lectures[i].Title} - {i}";
            }

            string progressBar = "|####################==========----------|";

            string result = $"-- {courseName}\r\n" +
                            $"{progressBar}\r\n" +
                            $"\r\n" +
                            $"{lecturePresentation}\r\n";

            PrintMessage(result);

            int selected = Int32.Parse(ConsoleRead());
            ShowTaskSetMenu(lectures[selected]);
        }

        public void ShowTaskSetMenu(Lecture lecture)
        {
            string lectureName = lecture.Title;
            TaskSet taskSet = lecture.TaskSet;
            taskSet.Tasks.Add(new Task() {Title = "Task 1"});
            string taskSetPresentation = "**** Task Set Menu ****\r\n" +
                                         $"Lecture seen: {(lecture.Finished ? "yes" : "no")}\r\n" +
                                         "Change done status? (y/n)\r\n";

            for (int i = 0; i < taskSet.Tasks.Count; i++)
            {
                taskSetPresentation += $"{taskSet.Tasks[i].Title} - {i}\r\n";
            }

            PrintMessage(taskSetPresentation);

            int taskIndex = Int32.Parse(ConsoleRead());
            TaskMenu(taskSet.Tasks[taskIndex]);
        }

        public void TaskMenu(Task task)
        {
            string taskPresentation = $"*** {task.Title} ***\r\n" +
                                      $"{task.Description}\r\n" +
                                      $"Published: {(task.Published ? "yes" : "no")}\r\n" +
                                      $"Done: {(task.Finished ? "yes" : "no")}\r\n";
            PrintMessage(taskPresentation);

            PrintMessage("Change done status? (y/n)");
            switch (ConsoleRead())
            {
                case "y":
                    task.Finished = !task.Finished;
                    break;
                case "n":
                    // do nothing
                    break;
            }
        }


        public void PrintPercentageDone(int percentage)
        {
            throw new NotImplementedException();
        }

        public void ShowRegisterUserMenu()
        {
            throw new NotImplementedException();
        }

        public void ShowSelectSpecializationMenu()
        {
            throw new NotImplementedException();
        }

        public void ShowSelectOptionalCourseMenu()
        {
            throw new NotImplementedException();
        }



        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public string ConsoleRead()
        {
            PrintMessage("Enter option: ");
            return Console.ReadLine();
        }

        public string[] GetLoginCredentials()
        {
            throw new NotImplementedException();
        }
    }
}