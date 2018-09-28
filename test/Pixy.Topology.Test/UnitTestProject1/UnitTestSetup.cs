

namespace Pixy.Test
{
    using NUnit.Framework;

    [TestFixture]
    public class UnitTestSetup
    {

        [Test]
        public void Check()
        {
            Assert.Pass();
        }
    }
}


namespace Pixy.Test.Topology
{
    using NUnit.Framework;
    using Pixy.Topology.Nodes;
    using System.Collections.Generic;
    using System.Linq;

    [TestFixture]
    public class UnitTest
    {
        public static IEnumerable<EP[]> e = new[]
        {
            new[]
            {
                new EP(),
                new EP(),
                new EP(),
                new EP(),
                new EP()
            }
        };


        [Test]
        [TestCaseSource("e")]
        public void StructureCheck(IEnumerable<EP> eps)
        {

            var sx = new SX();

            foreach (var ep in eps)
            {
                var a = sx.Increase(ep);
                Assert.IsTrue(a);
            }

            Assert.AreEqual(sx.Payload.Current, 5);


            var tmp = new EP();
            var b = sx.Increase(tmp);
            Assert.IsFalse(b);

            b = sx.Decrease(eps.Last());
            Assert.IsTrue(b);
            Assert.AreEqual(sx.Payload.Current, 4);
        }
    }
}
