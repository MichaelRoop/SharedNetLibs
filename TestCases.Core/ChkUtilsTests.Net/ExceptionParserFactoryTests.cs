using ChkUtils.Net.ExceptionParsers;
using NUnit.Framework;
using System.Xml;

namespace TestCases.ChkUtilsTests.Net {

    [TestFixture]
    public class ExceptionParserFactoryTests {

        [Test]
        public void XmlExeptionParserFetch() {
            this.TestParserFetch(typeof(XmlExceptionParser), () => {
                throw new XmlException("Blah Error", null, 25, 100);
            });
        }


        [Test]
        public void ExeptionParserFetch() {
            this.TestParserFetch(typeof(DefaultExceptionParser), () => {
                throw new Exception("Blah Error");
            });
        }


        [Test]
        public void DefaultExeptionParserFetch() {
            this.TestParserFetch(typeof(DefaultExceptionParser), () => {
                throw new InsufficientMemoryException("Wonka wonka out of memory");
            });
        }



#pragma warning disable CA1822 // Mark members as static
        private void TestParserFetch(Type expected, Action action) {
#pragma warning restore CA1822 // Mark members as static
            try {
                action.Invoke();
            }
            catch (Exception e) {
                IExceptionParser? parser = ExceptionParserFactory.Get(e);
                Assert.IsNotNull(parser);
                if (parser != null) {
                    Assert.AreEqual(expected.Name, parser.GetType().Name, "Factory returned wrong type of parser");
                }
            }
        }




    }
}
