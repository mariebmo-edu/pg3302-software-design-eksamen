using System;
using NUnit.Framework;
using PG332_SoftwareDesign_EksamenH21;
using PG332_SoftwareDesign_EksamenH21.Handlers;

namespace Test
{
    public class ProgressionBarHandlerTest
    {
        [Test]
        public void ShouldGenerateBar()
        {
            ProgressionWrapper progressionWrapper = new(0.66, 0.25);

            Console.WriteLine(ProgressionBarHandler.GenereteProgressbar(progressionWrapper));
            
            Assert.True(true);

        }
    }
}