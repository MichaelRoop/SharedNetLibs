using ChkUtils.Net;
using NUnit.Framework;
using System.Diagnostics;

namespace TestCases.ChkUtilsTests.Net {

    [TestFixture]
    public class StackFrameToolsTests {

        StackTools stackTools = new StackTools();

        #region LineNumber
        // Region put at top of file to avoid having expected line number changed

        [Test]
        public void LineNumber_nullFrame() {
            Assert.AreEqual(0, StackTools.Line(null));
        }

        /// <summary>MAKE SURE YOU ADJUST EXPECTED FILE LINE AFTER FILE MODIFIED</summary>
        [Test]
        public void LineNumber_withNumber() {
            Assert.AreEqual(23, StackTools.Line(new StackTrace(true).GetFrame(0)));
        }

        #endregion

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

        #region ColumnNumber

        /// <summary>Column is start of Assert method. Don´t change spacing</summary>
        [Test]
        public void Column_withNumber() {
            Assert.AreEqual(13, StackTools.Column(new StackTrace(true).GetFrame(0)));
        }

        /// <summary>Always return 0 column on failure</summary>
        [Test]
        public void Column_nullFrame() {
            Assert.AreEqual(0, StackTools.Column(null));
        }


        #endregion

        #region FirstNonWrappedMethod

        [Test]
        public void FirstNonWrappedMethod_valid() {
            WrapErr.SafeAction(() => {
                this.TestMethodBase("FirstNonWrappedMethod_valid",
                    this.stackTools.FirstNonWrappedMethod(typeof(WrapErr)));
            });
        }

        [Test]
        public void FirstNonWrappedMethod_multiTypes() {
            // Need to wrap the call into other classes to test the ignore of those classes on stack
            WrapErr.SafeAction(() => {
                WrappingClass1 t1 = new WrappingClass1();
                t1.DoIt(() => {
                    Type[] types = new Type[] { typeof(WrapErr), typeof(WrappingClass1) };
                    this.TestMethodBase("FirstNonWrappedMethod_multiTypes",
                        this.stackTools.FirstNonWrappedMethod(types));
                    });
                });
        }


        [Test]
        public void FirstNonWrappedMethod_caught() {
            // The catcher calls the FirstNonWrappedMethod and tells it to ignore any of its class
            // methods in order to retrieve the first method beyond it
            this.TestMethodBase("FirstNonWrappedMethod_caught", new ExceptionCatcher().DoIt());
        }


        private void TestMethodBase(string method, ErrorLocation loc) {
            Assert.AreEqual(method, loc.MethodName);
            Assert.AreEqual("StackFrameToolsTests", loc.ClassName);
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

        [Test]
        public void FirstNonWrappedTraceStack_caught() {
            // The catcher calls the FirstNonWrappedMethod and tells it to ignore any of its class
            // methods in order to retrieve the first method beyond it
            //this.TestMethodBase("FirstNonWrappedMethod_caught", new ExceptionCatcher().DoIt());

            //StackTools s = new StackTools();

            List<string> ss = new();

            try {
                new ExceptionThrower3().DoIt();
                Assert.Fail("It should not have gotten here - exception not thrown");
                //could return a ErrorLocation to parse in common method
                //this.stackTools.FirstNonWrappedMethod(this.GetType());



            }
            catch (Exception ex) {
                // this will list 1 and 2 and this method name
                //List<string> ss = this.stackTools.FirstNonWrappedTraceStack(typeof (ExceptionThrower3), ex, 0);

                // gets all 3 levels and this calling method name since it ignores something not in the stack
                ss = this.stackTools.FirstNonWrappedTraceStack(typeof (WrapErr), ex, 0);

                // this method does not get the names of class etc
                //List<string> ss = this.stackTools.FirstNonWrappedTraceStack(typeof(WrapErr), 0);


                //Assert.AreEqual("", )
                foreach (string s in ss) {
                    Debug.Write("");
                    Debug.Write(s);
                    Debug.WriteLine("");
                }

                //// Ignore all methods from this type to get the first method above it
                //return s.FirstNonWrappedMethod(this.GetType());
            }

            Assert.True(Array.Find(ss.ToArray(), s => s.Contains("ExceptionThrower.DoIt")) != null, "Not found ExceptionThrower.DoIt");
            Assert.True(Array.Find(ss.ToArray(), s => s.Contains("ExceptionThrower2.DoIt")) != null, "Not found ExceptionThrower.DoIt2");
            Assert.True(Array.Find(ss.ToArray(), s => s.Contains("ExceptionThrower3.DoIt")) != null, "Not found ExceptionThrower.DoIt3");
        }



        #region TODO

        //List<string> FirstNonWrappedTraceStack(Type typeToIgnore, int fromLevel);
        //List<string> FirstNonWrappedTraceStack(Type typeToIgnore, Exception ex, int fromLevel);
        //void FindNestedExceptionType<T>(Exception e, Action<bool, T?> onComplete) where T : Exception;

        #endregion

        #region Helper classes

        public class WrappingClass1 {
            public WrappingClass1() { }
            public void DoIt(Action action) { 
                action();
            }
        }


        public class ExceptionThrower {
            public void DoIt() {
                throw new Exception("Blah");
            }
        }

        public class ExceptionThrower2 {
            public void DoIt() {
                try {
                    new ExceptionThrower().DoIt();
                }
                catch (Exception) {
                    //throw new Exception("Nested 2 exception");
                    throw;
                }
            }
        }


        public class ExceptionThrower3 {
            public void DoIt() {
                try {
                    new ExceptionThrower2().DoIt();
                }
                catch (Exception) {
                    throw;
                    //throw new Exception("Nested 3 exception");
                }
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
                    return s.FirstNonWrappedMethod(this.GetType());
                }
            }

            public ErrorLocation DoIt2() { return this.DoIt3(); }
            public ErrorLocation DoIt() { return this.DoIt2(); }
        }


        #endregion


    }
}
