using System;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class ConsoleUi : IConsoleUi 
    {
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintPercentageDone(int percentage)
        {
            throw new System.NotImplementedException();
        }

        public void ShowMainMenu()
        {
            throw new System.NotImplementedException();
        }

        public void ShowSubMenu()
        {
            throw new System.NotImplementedException();
        }

        public void ShowRegisterUserMenu()
        {
            throw new System.NotImplementedException();
        }

        public void ShowSelectSpecializationMenu()
        {
            throw new System.NotImplementedException();
        }

        public void ShowSelectOptionalCourseMenu()
        {
            throw new System.NotImplementedException();
        }
    }
}