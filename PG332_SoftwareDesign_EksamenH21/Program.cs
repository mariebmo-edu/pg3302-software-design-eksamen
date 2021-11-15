using System;
using System.Linq;
using PG332_SoftwareDesign_EksamenH21.Model;
using PG332_SoftwareDesign_EksamenH21.Repository;

namespace PG332_SoftwareDesign_EksamenH21
{
    class Program
    {

        static void Main(string[] args)
        {
            for (int i = 0; i < 101; i++)
            {
                Console.Write("#");
            }
            AddDummyData();
            IConsoleUi ui = new ConsoleUi();
            ui.start();
        }


        private static void AddDummyData()
        {
            ConfigFile cf = new();
            cf.AddDummyData();
        }
    }
}