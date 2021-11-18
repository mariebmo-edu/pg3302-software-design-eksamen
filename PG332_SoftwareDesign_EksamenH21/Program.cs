using System.IO;
using Microsoft.EntityFrameworkCore.Internal;
using PG332_SoftwareDesign_EksamenH21.Controllers;
using PG332_SoftwareDesign_EksamenH21.Repository;
using PG332_SoftwareDesign_EksamenH21.util;

namespace PG332_SoftwareDesign_EksamenH21
{
    internal static class Program
    {
        private static void Main()
        {
            var users = new UserDao().ListAll();
            if (users == null || users.Count == 0)
                ConfigFile.AddDummyData();
            
            IReader reader = new Reader();
            new ProgramController(reader).Start();
        }
    }
}