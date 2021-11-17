using NUnit.Framework;
using PG332_SoftwareDesign_EksamenH21.util;

namespace Test
{
    public class SingletonTest
    {

        [Test]
        public void SingletonHasSameReference()
        {
            Logger logger1 = Logger.Instance;
            Logger logger2 = Logger.Instance;
            Assert.True(ReferenceEquals(logger1,logger2));
        }
    }
}