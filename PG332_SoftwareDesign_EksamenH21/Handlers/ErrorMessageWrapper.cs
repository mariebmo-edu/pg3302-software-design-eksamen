namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class ErrorMessageWrapper : IPrintable
    {
        public IPrintable SuperOption { get; set; }
        public string ErrorMessage { get; set; }
        
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