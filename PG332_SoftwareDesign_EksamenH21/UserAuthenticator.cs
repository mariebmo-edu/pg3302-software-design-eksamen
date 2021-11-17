using PG332_SoftwareDesign_EksamenH21.Controllers;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;
using static BCrypt.Net.BCrypt;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class UserAuthenticator
    {
        private readonly UserController _userController;
        private MenuPrinter<IProgressable> MenuPrinter = new();
        public User User { get; set; }
        
        public User Authenticate()
        {
            string email = MenuPrinter.AskForEmail();
            string password = MenuPrinter.AskForPassword();
            while ((User = UserValid(email, password)) == null)
            {
                MenuPrinter.ErrorWithAuthentication();
                email = MenuPrinter.AskForEmail();
                password = MenuPrinter.AskForPassword();
            }
            return User;
        }

        private User UserValid(string email, string password)
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