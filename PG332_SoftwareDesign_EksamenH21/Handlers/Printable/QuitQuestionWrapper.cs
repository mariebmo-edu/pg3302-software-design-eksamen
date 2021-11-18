namespace PG332_SoftwareDesign_EksamenH21.Handlers.Printable
{
    public class QuitQuestionWrapper : IPrintableWithSuper
    {
        public IPrintable SuperOption { get; set; }

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