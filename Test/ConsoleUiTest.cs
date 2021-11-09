using System;
using System.IO;
using NUnit.Framework;
using PG332_SoftwareDesign_EksamenH21;

namespace Test
{
    public class ConsoleUiTest
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase("Hello") ]
        [TestCase("Dette er en tekst")]
        public void ShouldPrintToConsole(string input)
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            ConsoleUi consoleUi = new ConsoleUi();
            consoleUi.PrintMessage(input);
            
            Assert.AreEqual(input + "\r\n", stringWriter.ToString());
        }

    }
}