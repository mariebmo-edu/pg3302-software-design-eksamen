namespace PG332_SoftwareDesign_EksamenH21.Handlers
{
    public interface IPrintable
    {
        public IPrintable SuperOption { get; set; }
        public IPrintable ChooseOption(string input);
    }
}