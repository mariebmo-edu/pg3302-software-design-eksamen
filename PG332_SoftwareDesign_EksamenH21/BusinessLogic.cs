using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class BusinessLogic
    {
        private IUserInterface UI { get; } = new UserInterface();
        private User User;
        
        
        public BusinessLogic(IUserInterface ui)
        {
            UI = ui;
        }

        public void StartProgram() 
        {
            User = UI.GetLoginCredentials(); // Må først få bruker til å logge inn
            while (!UserValid(User))
            {
                User = UI.GetLoginCredentials(); // Så lenge bruker ikke er gyldig ber vi dem prøve igjen.
            }
            ExecuteUserChoice();
        }

        private bool UserValid(User user)
        {
            UserDao dao = new UserDao();
            User actual = dao.RetrieveByEmail(user.Email);
            // TODO: Sjekke for passord her??
            return user.Id == actual.Id;
        }

        private void ExecuteUserChoice()
        {
            UI.ShowMenuOptions();
            UserChoice userChoice = UI.GetUserChoice();

            switch (userChoice)
            {
                case UserChoice.GetSemesterProgression:
                {
                    if (User.SpecializationId != null)
                        new SpecializationDao().RetrieveById((long) User.SpecializationId);
                    break;
                }
            }
        }

        public User GetLoggedInUser()
        {
            return User;
        }
    }
    
}