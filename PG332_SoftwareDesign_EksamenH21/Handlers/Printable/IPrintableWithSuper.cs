namespace PG332_SoftwareDesign_EksamenH21.Handlers.Printable
{
    public interface IPrintableWithSuper : IPrintable
    {
        public IPrintable SuperOption { get; set; }
    }
}