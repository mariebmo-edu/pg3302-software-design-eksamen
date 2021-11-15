using System;
using System.IO;
using NUnit.Framework;
using PG332_SoftwareDesign_EksamenH21;
using PG332_SoftwareDesign_EksamenH21.Model;

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

        [Test]
        public void ShouldPrintMainMenu()
        {
            var stringWriter = new StringWriter();
            Console.SetOut(stringWriter);
            
            ConsoleUi consoleUi = new ConsoleUi();
            consoleUi.ShowMainMenu("harry");
            
            // Expected:
            string name = "Harry";
            string semester = "3";
            string progressionBar = "|####################==========----------|";
            string expected = $"Velkommen, {name}\r\n" +
                              $"Nåværende semester: {semester}\r\n" +
                              $"{progressionBar}\r\n" +
                              "\r\n" +
                              $"Velg emne:\r\n" +
                              $"1 - AdvJava\r\n" +
                              $"2 - SoftDes\r\n" +
                              $"3 - AlgDat\r\n" +
                              $"4 - SmiPro\r\n" +
                              "\r\n" +
                              $"0 - gå til spesialiseringsmeny\r\n" +
                              "\r\n" +
                              "E - avslutt\r\n";
            Assert.AreEqual(expected, stringWriter);
        }

    }
}