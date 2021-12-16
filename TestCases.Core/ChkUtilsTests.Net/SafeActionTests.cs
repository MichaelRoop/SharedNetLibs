using ChkUtils.Net;
using NUnit.Framework;

namespace TestCases.ChkUtilsTests.Net {

    [TestFixture]
    public class SafeActionTests {

        [Test]
        public void NoExceptionPropagation() {
            Assert.DoesNotThrow(() => {
                WrapErr.SafeAction(() => {
                    Console.WriteLine("Throwing Exception within safe block");
                    throw new Exception("This should be caught");
                });
            });
        }


        class Obj1 {
        }

        [Test]
        public void DefaultObjectOnThrow() {
            // The safe wrapper should overwrite the valid object with default(obj1)
            Obj1 o1 = new ();
            Assert.DoesNotThrow(() => {
                o1= WrapErr.SafeAction(() => {
#pragma warning disable CS8600,CS8602
                    string s2 = null;
                    string s3 = s2[..10];
#pragma warning restore CS8600,CS8602
                    return new Obj1();
                });
            });
            Assert.AreEqual(o1, default(Obj1));
            Assert.IsNull(o1);
        }


        [Test]
        public void ReturnsValidObj() {
            // The safe wrapper should overwrite the valid object with default(obj1)
            Obj1? o1 = null;
            Assert.DoesNotThrow(() => {
                o1 = WrapErr.SafeAction(() => {
                    return new Obj1();
                });
            });
            Assert.IsNotNull(o1);
        }



    }
}
