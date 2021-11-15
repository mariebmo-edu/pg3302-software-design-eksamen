namespace PG332_SoftwareDesign_EksamenH21
{
    public interface IConsoleUi
    {
        void UserLoginMenu();
        void PrintMessage(string message);

        void PrintPercentageDone(int percentage);

        void ShowMainMenu(string fullName);

        void ShowCourseMenu(int courseId);

        void ShowTaskSetMenu(Lecture lecture);

        void TaskMenu(Task task);

        void ShowRegisterUserMenu();

        void ShowSelectSpecializationMenu();

        void ShowSelectOptionalCourseMenu();
        void start();
        string[] GetLoginCredentials();
    }
}