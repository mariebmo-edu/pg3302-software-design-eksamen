using PG332_SoftwareDesign_EksamenH21.Controllers;
using PG332_SoftwareDesign_EksamenH21.Repository;

namespace PG332_SoftwareDesign_EksamenH21
{
    class Program
    {
        static void Main(string[] args)
        {
            var users = new UserDao().ListAll();
            if (users == null || users.Count == 0)
                ConfigFile.AddDummyData();
            
            IReader reader = new Reader();
            new ProgramController(reader).Start();
        }
    }
}