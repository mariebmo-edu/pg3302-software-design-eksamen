using NUnit.Framework;
using PG332_SoftwareDesign_EksamenH21.util;

namespace Test
{
    public class SingletonTest
    {

        [Test]
        public void SingletonHasSameReference()
        {
            var logger1 = Logger.Instance;
            var logger2 = Logger.Instance;
            Assert.True(ReferenceEquals(logger1,logger2));
        }
    }
}