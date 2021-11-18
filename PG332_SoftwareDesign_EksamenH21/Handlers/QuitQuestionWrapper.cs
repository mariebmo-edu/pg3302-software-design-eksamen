namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class QuitQuestionWrapper : IPrintable
    {
        private IPrintable SuperOption { get; }

        public QuitQuestionWrapper(IPrintable superOption)
        {
            SuperOption = superOption;
        }
        
        public IPrintable ChooseOption(string input)
        {
            return input.ToLower() == "j" ? new QuitMessageWrapper() : SuperOption;
        }
    }
}