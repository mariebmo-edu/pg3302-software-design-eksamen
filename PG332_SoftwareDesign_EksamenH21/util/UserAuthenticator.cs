using PG332_SoftwareDesign_EksamenH21.Controllers;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;
using static BCrypt.Net.BCrypt;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class UserAuthenticator
    {
        private readonly ProgramController _programController;
        private MenuPrinter MenuPrinter = new();
        public User User { get; set; }
        
        // public User Authenticate(string email, string password)
        // {
        //     while ((User = UserValid(email, password)) == null)
        //     {
        //         MenuPrinter.ErrorWithAuthentication();
        //         email = MenuPrinter.AskForEmail();
        //         password = MenuPrinter.AskForPassword();
        //     }
        //     return User;
        // }

        public User Authenticate(string email, string password)
        {
            UserDao dao = new UserDao();
            User retrieveByEmail = dao.RetrieveByEmail(email);
            if (retrieveByEmail is null) return null;

            if (Verify(password, retrieveByEmail.Password))
            {
                return retrieveByEmail;
            }
            return null;
        }
    }
}