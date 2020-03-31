using ChkUtils;
using ChkUtils.ErrObjects;
using NUnit.Framework;
using System;

namespace TestCases.ChkUtilsTests {

    [TestFixture]
    public class ValidatorTests {

        #region Param

        [Test]
        public void Param_NullArg() {
            ErrReport err;
            WrapErr.ToErrReport(out err, 1111, "Validate arg", () => {
                WrapErr.ChkParam(null, "zork", 8888);
            });
            this.Validate(err, 8888, "Param_NullArg", "Null zork Argument");
        }

        [Test]
        public void Param_ValidArg() {
            string zork = "Zorker";
            ErrReport err;
            WrapErr.ToErrReport(out err, 1111, "Validate arg", () => {
                WrapErr.ChkParam(zork, "zork", 8888);
            });
            Assert.AreEqual(0, err.Code, "Should not have been an error");
        }

        #endregion

        #region Var

        [Test]
        public void Var_NullArg() {
            ErrReport err;
            WrapErr.ToErrReport(out err, 1111, "Validate arg", () => {
                WrapErr.ChkVar(null, 8888, "zork error");
            });
            this.Validate(err, 8888, "Var_NullArg", "zork error");
        }

        [Test]
        public void Var_ValidArg() {
            string zork = "Zorker";
            ErrReport err;
            WrapErr.ToErrReport(out err, 1111, "Validate arg", () => {
                WrapErr.ChkVar(zork, 8888, "zork error");
            });
            Assert.AreEqual(0, err.Code, "Should not have been an error");
        }

        #endregion

        #region True

        [Test]
        public void True_Fail() {
            ErrReport err;
            WrapErr.ToErrReport(out err, 1111, "Validate arg", () => {
                WrapErr.ChkTrue(false, 8888, "zork error");
            });
            this.Validate(err, 8888, "True_Fail", "zork error");
        }

        [Test]
        public void True_Valid() {
            ErrReport err;
            WrapErr.ToErrReport(out err, 1111, "Validate arg", () => {
                WrapErr.ChkTrue(true, 8888, "zork error");
            });
            Assert.AreEqual(0, err.Code, "Should not have been an error");
        }

        #endregion

        #region Disposed

        [Test]
        public void Disposed_Fail() {
            ErrReport err;
            WrapErr.ToErrReport(out err, 1111, "Validate arg", () => {
                WrapErr.ChkDisposed(true, 8888);
            });
            this.Validate(err, 8888, "Disposed_Fail", "Attempting to use Disposed Object");
        }

        [Test]
        public void Disposed_Valid() {
            ErrReport err;
            WrapErr.ToErrReport(out err, 1111, "Validate arg", () => {
                WrapErr.ChkDisposed(false, 8888);
            });
            Assert.AreEqual(0, err.Code, "Should not have been an error");
        }

        #endregion

        #region False

        [Test]
        public void False_Fail() {
            ErrReport err;
            WrapErr.ToErrReport(out err, 1111, "Validate arg", () => {
                WrapErr.ChkFalse(true, 8888, "zork error");
            });
            this.Validate(err, 8888, "False_Fail", "zork error");
        }

        [Test]
        public void False_Valid() {
            ErrReport err;
            WrapErr.ToErrReport(out err, 1111, "Validate arg", () => {
                WrapErr.ChkFalse(false, 8888, "zork error");
            });
            Assert.AreEqual(0, err.Code, "Should not have been an error");
        }

        #endregion

        #region String

        [Test]
        public void String_Null() {
            string zork = null;
            ErrReport err;
            WrapErr.ToErrReport(out err, 1111, "Validate arg", () => {
                WrapErr.ChkStr(1111, 2222, "zork", zork);
            });
            this.Validate(err, 1111, "String_Null", "String 'zork' is Null");
        }

        [Test]
        public void String_Empty() {
            string zork = "";
            ErrReport err;
            WrapErr.ToErrReport(out err, 1111, "Validate arg", () => {
                WrapErr.ChkStr(1111, 2222, "zork", zork);
            });
            this.Validate(err, 2222, "String_Empty", "String 'zork' is Empty");
        }

        #endregion
        
        #region Throw Correct Exception Type

        [Test]
        public void ExceptionType_Regular_Param() {
            CheckExceptionType(() => { WrapErr.ChkParam(null, "zork", 8888); });
        }

        [Test]
        public void ExceptionType_Regular_Var() {
            CheckExceptionType(() => { WrapErr.ChkVar(null, 8888, "Bad var"); });
        }

        [Test]
        public void ExceptionType_Regular_True() {
            CheckExceptionType(() => { WrapErr.ChkTrue(false, 8888, "false"); });
        }

        [Test]
        public void ExceptionType_Regular_False() {
            CheckExceptionType(() => { WrapErr.ChkTrue(true, 8888, "true"); });
        }

        [Test]
        public void ExceptionType_Regular_String_Null() {
            CheckExceptionType(() => { WrapErr.ChkStr(1111, 2222, "stringName", null); });
        }

        [Test]
        public void ExceptionType_Regular_String_Empty() {
            CheckExceptionType(() => { WrapErr.ChkStr(1111, 2222, "stringName", ""); });
        }

        private void CheckExceptionType(Action action) {
            try {
                action.Invoke();
            }
            catch (ErrReportException) {
                return;
            }
            catch (Exception e) {
                Assert.Fail("Got and exption type {0} while expecting ErrReportException", e.GetType().Name);
            }
        }

        #endregion
        
        #region Private Methods

        private void Validate(ErrReport err, int code, string method, string msg) {
            TestHelpers.ValidateErrReport(err, code, "ValidatorTests", method, msg);
//            Assert.AreEqual("", err.StackTrace);
        }

        #endregion



    }
}
