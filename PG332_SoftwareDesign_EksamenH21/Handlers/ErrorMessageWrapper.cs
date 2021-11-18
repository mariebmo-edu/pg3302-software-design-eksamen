namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class ErrorMessageWrapper : IPrintable
    {
        private IPrintable SuperOption { get; }
        public string ErrorMessage { get; }
        
        public ErrorMessageWrapper(string errorMessage, IPrintable superOption)
        {
            ErrorMessage = errorMessage;
            SuperOption = superOption;
        }
        
        public IPrintable ChooseOption(string input)
        {
            return SuperOption;
        }
    }
}