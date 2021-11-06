using System;
using PG332_SoftwareDesign_EksamenH21.Controllers;

namespace PG332_SoftwareDesign_EksamenH21.Stubs
{
    public class ConsoleUiStub
    {
        private UserController _userController = new UserController();
        public void PrintMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void ShowRegisteUserMenu()
        {

            string userInput = "1";
            PrintMessage("Show user");
            PrintMessage("Enter user Id: ");
            PrintMessage(_userController.GetUserById(userInput));
        }

        public void AddUserMenu()
        {
            PrintMessage(_userController.RegisterNewUser());
        }

    }
    
    
    
}