using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.util;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class PasswordQuestionWrapper : IPrintable
    {
        private IPrintable SuperOption { get; }
        private string Email { get; }
        public IPrintable ChooseOption(string input)
        {
            var user = Authenticate(input);
            if (user != null)
            {
                return new LoginMessageWrapper("Velkommen!", user);
            }

            return new ErrorMessageWrapper("Autentiseringsfeil - Feil epost eller passord!", SuperOption);
        }

        public PasswordQuestionWrapper(string email, IPrintable superOption)
        {
            Email = email;
            SuperOption = superOption;
        }

        private User Authenticate(string password)
        {
            return UserAuthenticator.Authenticate(Email, password);
        }
    }
}