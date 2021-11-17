namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public class QuitMessageWrapper : IPrintable
    {
        public IPrintable SuperOption { get; set; } = null;
        public IPrintable ChooseOption(string input)
        {
            return null;
        }
    }
}