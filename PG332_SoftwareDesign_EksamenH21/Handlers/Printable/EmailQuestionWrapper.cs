namespace PG332_SoftwareDesign_EksamenH21.Handlers.Printable
{
    public class EmailQuestionWrapper : IPrintable
    {
        public IPrintable ChooseOption(string input)
        {
            return new PasswordQuestionWrapper(input, this);
        }
    }
}