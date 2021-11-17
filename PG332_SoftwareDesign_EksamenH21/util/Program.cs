using PG332_SoftwareDesign_EksamenH21.Controllers;

namespace PG332_SoftwareDesign_EksamenH21
{
    class Program
    {
        static void Main(string[] args)
        {
            new ConfigFile().AddDummyData();
            new UserController().Start();
        }
    }
}