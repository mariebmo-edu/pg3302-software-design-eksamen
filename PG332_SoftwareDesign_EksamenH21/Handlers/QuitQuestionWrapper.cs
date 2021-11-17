namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class QuitQuestionWrapper : IPrintable
    {
        public IPrintable SuperOption { get; set; }

        public QuitQuestionWrapper(OptionsWrapper superOption)
        {
            SuperOption = superOption;
        }
        
        public IPrintable ChooseOption(string input)
        {
            if (input.ToLower() == "j")
            {
                return new QuitMessageWrapper();
            }

            return SuperOption;
        }
    }
}