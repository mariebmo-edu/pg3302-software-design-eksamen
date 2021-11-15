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
            ProgressionWrapper progressionWrapper = new(0.50, 0.25);

            String _expected =
                "|#########################=========================--------------------------------------------------|";

            Assert.AreEqual(_expected, ProgressionBarHandler.GenerateProgressBar(progressionWrapper));
        }
    }
}