using System;

namespace PG332_SoftwareDesign_EksamenH21
{
    public class Reader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}