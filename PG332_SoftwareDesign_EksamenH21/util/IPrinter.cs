using PG332_SoftwareDesign_EksamenH21.Handlers;
using PG332_SoftwareDesign_EksamenH21.Handlers.Printable;

namespace PG332_SoftwareDesign_EksamenH21.util
{
    public interface IPrinter
    {
        public void ShowMenu(IPrintable printable);
    }
}