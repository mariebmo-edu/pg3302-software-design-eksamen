using PG332_SoftwareDesign_EksamenH21.Controllers;
using PG332_SoftwareDesign_EksamenH21.util;

namespace PG332_SoftwareDesign_EksamenH21
{
    class Program
    {
        static void Main(string[] args)
        {
            new ConfigFile().AddDummyData();
            IReader reader = new Reader();
            new ProgramController(reader).Start();
        }
    }
}