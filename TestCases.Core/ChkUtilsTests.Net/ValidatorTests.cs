using ChkUtils.Net;
using ChkUtils.Net.ErrObjects;
using ChkUtils.Net.Interfaces;
using NUnit.Framework;
using TestCaseSupport.Core;

namespace TestCases.ChkUtilsTests.Net {

    [TestFixture]
    public class ValidatorTests {
#pragma warning disable CA1822 // Mark members as static

        [OneTimeSetUp]
        public void DoOneTimeSetup() {
            // Need stack tools to get stack to validate exception class and method
            IStackTools s = new StackTools();
            WrapErr.SetStackTools(s);
        }

        #region Param

        [Test]
        public void Param_NullArg() {
            WrapErr.ToErrReport(out ErrReport err, 1111, "Validate arg", () => {
                WrapErr.ChkParam(null, "zork", 8888);
            });
            this.Validate(err, 8888, "Param_NullArg", "Null zork Argument");
        }

        [Test]
        public void Param_ValidArg() {
            string zork = "Zorker";
            WrapErr.ToErrReport(out ErrReport err, 1111, "Validate arg", () => {
                WrapErr.ChkParam(zork, "zork", 8888);
            });
            Assert.AreEqual(0, err.Code, "Should not have been an error");
        }

        [Test]
        public void Param_NullArg_FaultException() {
            WrapErr.ToErrReport(out ErrReport err, 1111, "Validate arg", () => {
                WrapErr.ChkParam(null, "zork", 8888);
            });
            this.Validate(err, 8888, "Param_NullArg_FaultException", "Null zork Argument");
        }

        [Test]
        public void Param_ValidArg_FaultException() {
            string zork = "Zorker";
            WrapErr.ToErrReport(out ErrReport err, 1111, "Validate arg", () => {
                WrapErr.ChkParam(zork, "zork", 8888);
            });
            Assert.AreEqual(0, err.Code, "Should not have been an error");
        }
        
        #endregion

        #region Var

        [Test]
        public void Var_NullArg() {
            WrapErr.ToErrReport(out ErrReport err, 1111, "Validate arg", () => {
                WrapErr.ChkVar(null, 8888, "zork error");
            });
            this.Validate(err, 8888, "Var_NullArg", "zork error");
        }

        [Test]
        public void Var_ValidArg() {
            string zork = "Zorker";
            WrapErr.ToErrReport(out ErrReport err, 1111, "Validate arg", () => {
                WrapErr.ChkVar(zork, 8888, "zork error");
            });
            Assert.AreEqual(0, err.Code, "Should not have been an error");
        }

        [Test]
        public void Var_NullArg_FaultException() {
            WrapErr.ToErrReport(out ErrReport err, 1111, "Validate arg", () => {
                WrapErr.ChkVar(null, 8888, "zork error");
            });
            this.Validate(err, 8888, "Var_NullArg_FaultException", "zork error");
        }

        [Test]
        public void Var_ValidArg_FaultException() {
            string zork = "Zorker";
            WrapErr.ToErrReport(out ErrReport err, 1111, "Validate arg", () => {
                WrapErr.ChkVar(zork, 8888, "zork error");
            });
            Assert.AreEqual(0, err.Code, "Should not have been an error");
        }


        #endregion

        #region True

        [Test]
        public void True_Fail() {
            WrapErr.ToErrReport(out ErrReport err, 1111, "Validate arg", () => {
                WrapErr.ChkTrue(false, 8888, "zork error");
            });
            this.Validate(err, 8888, "True_Fail", "zork error");
        }

        [Test]
        public void True_Fail_WithNullable() {
            //ErrReport err = new ErrReport();
            // To show that it will not flag a nullable error to compiler 
            // because of attribute it knows ChkTrue will throw and so
            // the operation on null string never happens
            string? n = null;
            try {
                WrapErr.ChkTrue(false, 8889, "zork error");
                string x = n;
                Assert.True(false, "Should not get here");
            }
            catch {
                Assert.True(true, "Should get here");
            }
        }


        [Test]
        public void True_Valid() {
            WrapErr.ToErrReport(out ErrReport err, 1111, "Validate arg", () => {
                WrapErr.ChkTrue(true, 8888, "zork error");
            });
            Assert.AreEqual(0, err.Code, "Should not have been an error");
        }

        #endregion

        #region Disposed

        [Test]
        public void Disposed_Fail() {
            WrapErr.ToErrReport(out ErrReport err, 1111, "Validate arg", () => {
                WrapErr.ChkDisposed(true, 8888);
            });
            this.Validate(err, 8888, "Disposed_Fail", "Attempting to use Disposed Object");
        }

        [Test]
        public void Disposed_Valid() {
            WrapErr.ToErrReport(out ErrReport err, 1111, "Validate arg", () => {
                WrapErr.ChkDisposed(false, 8888);
            });
            Assert.AreEqual(0, err.Code, "Should not have been an error");
        }

        #endregion

        #region False

        [Test]
        public void False_Fail() {
            WrapErr.ToErrReport(out ErrReport err, 1111, "Validate arg", () => {
                WrapErr.ChkFalse(true, 8888, "zork error");
            });
            this.Validate(err, 8888, "False_Fail", "zork error");
        }

        [Test]
        public void False_Valid() {
            WrapErr.ToErrReport(out ErrReport err, 1111, "Validate arg", () => {
                WrapErr.ChkFalse(false, 8888, "zork error");
            });
            Assert.AreEqual(0, err.Code, "Should not have been an error");
        }

        #endregion

        #region String

        [Test]
        public void String_Null() {
            string? zork = null;
            WrapErr.ToErrReport(out ErrReport err, 1111, "Validate arg", () => {
                WrapErr.ChkStr(1111, 2222, "zork", zork);
            });
            this.Validate(err, 1111, "String_Null", "String 'zork' is Null");
        }

        [Test]
        public void String_Empty() {
            string zork = "";
            WrapErr.ToErrReport(out ErrReport err, 1111, "Validate arg", () => {
                WrapErr.ChkStr(1111, 2222, "zork", zork);
            });
            this.Validate(err, 2222, "String_Empty", "String 'zork' is Empty");
        }

        [Test]
        public void String_Null_FaultException() {
            string? zork = null;
            WrapErr.ToErrReport(out ErrReport err, 1111, "Validate arg", () => {
                WrapErr.ChkStr(1111, 2222, "zork", zork);
            });
            this.Validate(err, 1111, "String_Null_FaultException", "String 'zork' is Null");
        }

        [Test]
        public void String_Empty_FaultException() {
            string zork = "";
            WrapErr.ToErrReport(out ErrReport err, 1111, "Validate arg", () => {
                WrapErr.ChkStr(1111, 2222, "zork", zork);
            });
            this.Validate(err, 2222, "String_Empty_FaultException", "String 'zork' is Empty");
        }

        #endregion

        #region Throw Correct Exception Type

        //[Test]
        //public void ExceptionType_Regular_Param() {
        //    CheckExceptionType(ExceptionType.Regular, () => { WrapErr.ChkParam(null, "zork", 8888); });
        //}

        //[Test]
        //public void ExceptionType_Regular_Var() {
        //    CheckExceptionType(ExceptionType.Regular, () => { WrapErr.ChkVar(null, 8888, "Bad var"); });
        //}

        //[Test]
        //public void ExceptionType_Regular_True() {
        //    CheckExceptionType(ExceptionType.Regular, () => { WrapErr.ChkTrue(false, 8888, "false"); });
        //}

        //[Test]
        //public void ExceptionType_Regular_False() {
        //    CheckExceptionType(ExceptionType.Regular, () => { WrapErr.ChkTrue(true, 8888, "true"); });
        //}

        //[Test]
        //public void ExceptionType_Regular_String_Null() {
        //    CheckExceptionType(ExceptionType.Regular, () => { WrapErr.ChkStr(1111, 2222, "stringName", null); });
        //}

        //[Test]
        //public void ExceptionType_Regular_String_Empty() {
        //    CheckExceptionType(ExceptionType.Regular, () => { WrapErr.ChkStr(1111, 2222, "stringName", ""); });
        //}


        //[Test]
        //public void ExceptionType_Fault_Param() {
        //    CheckExceptionType(ExceptionType.Fault, () => { WrapErr.ChkParam(ExceptionType.Fault, null, "zork", 8888); });
        //}

        //[Test]
        //public void ExceptionType_Fault_Var() {
        //    CheckExceptionType(ExceptionType.Fault, () => { WrapErr.ChkVar(ExceptionType.Fault, null, 8888, "Bad var"); });
        //}

        //[Test]
        //public void ExceptionType_Fault_True() {
        //    CheckExceptionType(ExceptionType.Fault, () => { WrapErr.ChkTrue(ExceptionType.Fault, false, 8888, "false"); });
        //}

        //[Test]
        //public void ExceptionType_Fault_False() {
        //    CheckExceptionType(ExceptionType.Fault, () => { WrapErr.ChkFalse(ExceptionType.Fault, true, 8888, "true"); });
        //}

        //[Test]
        //public void ExceptionType_Fault_StringNull() {
        //    CheckExceptionType(ExceptionType.Fault, () => { WrapErr.ChkStr(ExceptionType.Fault, 1111, 2222, "stringName", null); });
        //}

        //[Test]
        //public void ExceptionType_Fault_StringEmpty() {
        //    CheckExceptionType(ExceptionType.Fault, () => { WrapErr.ChkStr(ExceptionType.Fault, 1111, 2222, "stringName", ""); });
        //}




        //private void CheckExceptionType(ExceptionType type, Action action) {
        //    try {
        //        action.Invoke();
        //    }
        //    catch (ErrReportException e) {
        //        if (type == ExceptionType.Regular) {
        //            return;
        //        }
        //        Assert.Fail("Got and exption type {0} while expecting ", e.GetType().Name, type.ToString());
        //    }
        //    catch (FaultException<ErrReport> e) {
        //        if (type == ExceptionType.Fault) {
        //            return;
        //        }
        //        Assert.Fail("Got and exption type {0} while expecting ", e.GetType().Name, type.ToString());
        //    }
        //    catch (Exception e) {
        //        Assert.Fail("Got and exption type {0} while expecting ", e.GetType().Name, type.ToString());
        //    }
        //}

        #endregion

        #region Private Methods

        private void Validate(ErrReport err, int code, string method, string msg) {
            TestHelpers.ValidateErrReport(err, code, "ValidatorTests", method, msg);
        }

        #endregion
#pragma warning restore CA1822 // Mark members as static



    }
}
