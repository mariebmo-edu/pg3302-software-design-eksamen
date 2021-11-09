namespace PG332_SoftwareDesign_EksamenH21
{
    public interface IUserInterface
    {
        void PrintMessage(string message);

        void PrintPercentageDone(int percentage);

        void ShowMainMenu();

        void ShowSubMenu();

        void ShowRegisterUserMenu();

        void ShowSelectSpecializationMenu();

        void ShowSelectOptionalCourseMenu();
    }
}