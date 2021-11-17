namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class EmailQuestionWrapper : IPrintable
    {
        public IPrintable SuperOption { get; set; }
        public IPrintable ChooseOption(string input)
        {
            return new PasswordQuestionWrapper(input, this);
        }
    }
}