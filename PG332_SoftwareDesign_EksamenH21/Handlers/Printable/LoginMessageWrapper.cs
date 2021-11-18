using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers.Printable
{
    public class LoginMessageWrapper : IPrintable
    {
        public string Message { get; }
        private readonly User _user;
        public IPrintable ChooseOption(string input)
        {
            return OptionsWrapperFactory.MakeOptionsWrapper(_user);
        }

        public LoginMessageWrapper(string message, User user)
        {
            Message = message;
            _user = user;
        }
    }
}