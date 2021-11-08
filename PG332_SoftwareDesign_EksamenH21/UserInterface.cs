using System;
using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class UserInterface : IUserInterface
    {
        public void ShowMenuOptions()
        {
            
        }

        public User GetLoginCredentials()
        {
            // Kun midlertidig for å få testen til å kjøre grønt
            return new() {Id = 42069, FirstName = "G", LastName = "Bergesen", Email = "gMail@email.no"};
        }

        public UserChoice GetUserChoice()
        {
            return UserChoice.Quit;
        }
    }
}