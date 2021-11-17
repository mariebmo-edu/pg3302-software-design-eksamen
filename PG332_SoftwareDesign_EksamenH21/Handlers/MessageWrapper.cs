using PG332_SoftwareDesign_EksamenH21.Model;

namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class MessageWrapper : IPrintable
    {
        public IPrintable SuperOption { get; set; }
        public string Message { get; }
        private User _user;
        public IPrintable ChooseOption(string input)
        {
            return OptionsHandlerFactory.MakeOptionsHandler(_user, null);
        }

        public MessageWrapper(string message, User user)
        {
            Message = message;
            _user = user;
        }
    }
}