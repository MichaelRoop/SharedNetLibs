using ChkUtils.Net;
using NUnit.Framework;
using System.Diagnostics;

namespace TestCases.ChkUtilsTests.Net {

    [TestFixture]
    public class StackFrameToolsTests {

        StackTools stackTools = new StackTools();


        #region ClassName

        [Test]
        public void ClassName_nullFrame() {
            Assert.AreEqual("NoClassName", StackTools.ClassName(null));
        }

        [Test]
        public void ClassName_valid() {
            Assert.AreEqual("StackFrameToolsTests", StackTools.ClassName(new StackTrace().GetFrame(0)));
        }

        #endregion

        #region MethodName

        [Test]
        public void MethodName_nullFrame() {
            Assert.AreEqual("NoMethodName", StackTools.MethodName(null));
        }

        [Test]
        public void MethodName_valid() {
            Assert.AreEqual("MethodName_valid", StackTools.MethodName(new StackTrace().GetFrame(0)));
        }

        #endregion

        #region FileName

        [Test]
        public void FileName_nullFrame() {
            Assert.AreEqual("NoFileName", StackTools.FileName(null));
        }

        [Test]
        public void FileName_OutOfBoundsIndex() {
            Assert.AreEqual("NoFileName", StackTools.FileName(new StackTrace().GetFrame(30000)));
        }

        // TODO - figure out why this does not work - Frame.GetFileName always null
        [Test]
        public void FileName_valid() {
            Assert.AreEqual("StackFrameToolsTests.cs", StackTools.FileName(new StackTrace(true).GetFrame(0)));
        }

        #endregion

        #region LineNumber

        [Test]
        public void LineNumber_nullFrame() {
            Assert.AreEqual(0, StackTools.Line(null));
        }

        /// <summary>MAKE SURE YOU ADJUST EXPECTED FILE LINE AFTER FILE MODIFIED</summary>
        [Test]
        public void LineNumber_withNumber() {
            Assert.AreEqual(79, StackTools.Line(new StackTrace(true).GetFrame(0)));
        }

        #endregion

        #region ColumnNumber

        /// <summary>Column is start of Assert method. Don´t change spacing</summary>
        [Test]
        public void ColumnNumber_withNumber() {
            Assert.AreEqual(13, StackTools.Column(new StackTrace(true).GetFrame(0)));
        }

        /// <summary>Always return 0 column on failure</summary>
        [Test]
        public void ColumnNumber_nullFrame() {
            Assert.AreEqual(0, StackTools.Column(null));
        }


        #endregion

        #region FirstNonWrappedMethod

        [Test]
        public void FirstNonWrappedMethod_valid() {
            this.TestMethodBase("FirstNonWrappedMethod_valid",
                this.stackTools.FirstNonWrappedMethod(typeof(WrapErr)));
        }

        [Test]
        public void FirstNonWrappedMethod_multiTypes() {
            Type[] types = new Type[] { typeof(WrapErr), typeof(ErrorLocation) };
            this.TestMethodBase("FirstNonWrappedMethod_multiTypes",
                this.stackTools.FirstNonWrappedMethod(types));
        }


        [Test]
        public void FirstNonWrappedMethod_caught() {
            // The catcher calls the FirstNonWrappedMethod and tells it to ignore any of its class
            // methods in order to retrieve the first method beyond it
            this.TestMethodBase("FirstNonWrappedMethod_caught", new ExceptionCatcher().DoIt());
        }


        private void TestMethodBase(string method, ErrorLocation loc) {
            //Assert.NotNull(mb);
            //if (mb != null) {
            //Console.WriteLine("{0}.{1}", mb.DeclaringType.Name, mb.Name);
            //Assert.AreEqual(method, mb.Name);
            //Assert.NotNull(((MethodBase)mb).DeclaringType);
            //if (mb.DeclaringType != null) {
            //    Assert.AreEqual("StackFrameToolsTests", mb.DeclaringType.Name);
            //}
            Assert.AreEqual(method, loc.MethodName);
            Assert.AreEqual("StackFrameToolsTests", loc.ClassName);



            //}
        }



        //private void TestMethodBase(string method, MethodBase mb) {
        //    Assert.NotNull(mb);
        //    if (mb != null) {
        //        //Console.WriteLine("{0}.{1}", mb.DeclaringType.Name, mb.Name);
        //        Assert.AreEqual(method, mb.Name);
        //        Assert.NotNull(((MethodBase)mb).DeclaringType);
        //        if (mb.DeclaringType != null) { 
        //            Assert.AreEqual("StackFrameToolsTests", mb.DeclaringType.Name);
        //        }
        //    }
        //}

        public class ExceptionThrower {
            public void DoIt() {
                throw new Exception("Blah");
            }
        }

        public class ExceptionCatcher {

            public ErrorLocation DoIt3() {
                StackTools s = new StackTools();
                try {
                    new ExceptionThrower().DoIt();
                    Assert.Fail("It should not have gotten here - exception not thrown");
                    return s.FirstNonWrappedMethod(this.GetType());
                }
                catch (Exception) {
                    // Ignore all methods from this type to get the first method above it
                    return  s.FirstNonWrappedMethod(this.GetType());
                }
            }

            public ErrorLocation DoIt2() { return this.DoIt3(); }
            public ErrorLocation DoIt() { return this.DoIt2(); }
        }


        #endregion


        #region FirstNonWrappedTraceStack

        [Test]
        public void TraceStack_FullDisplay() {
            Debug.WriteLine("------------------------STARTING---------------------");

            List<string> stack = this.stackTools.FirstNonWrappedTraceStack(typeof(WrapErr), 0);
            foreach(string s in stack) {
                Debug.WriteLine(s);
            }



            //Assert.AreEqual("NoMethodName", 
            //    StackTools.MethodName(null));
        }




        #endregion


    }
}
