using NUnit.Framework;
using SpStateMachine.Core;
using SpStateMachine.Interfaces;
using System;
using System.Threading;
using TestCases.Core.TestToolSet;
using FakeItEasy;

namespace TestCases.SpStateMachineTests {

    [TestFixture]
    public class SpStateMachineEngineTests {

        #region Data

        HelperLogReaderNet logReader = new HelperLogReaderNet();

        public class engineParams {
            public ISpEventListner listner { get; set; } = A.Fake<ISpEventListner>();
            public ISpEventStore st { get; set; } = A.Fake<ISpEventStore>();
            public ISpBehaviorOnEvent be { get; set; } = A.Fake<ISpBehaviorOnEvent>();
            public ISpStateMachine sm { get; set; } = A.Fake<ISpStateMachine>();
            public ISpPeriodicTimer tm { get; set; } = A.Fake<ISpPeriodicTimer>();
        }

        engineParams p = new engineParams();

        #endregion

        #region Setup

        [SetUp]
        public void TestSetup() {
            this.logReader.StartLogging();
        }

        [TearDown]
        public void TestTeardown() {
            this.logReader.StopLogging();
            this.logReader.Clear();
        }

        #endregion

        #region Start

        [Test]
        public void _50056_StartDisposed() {
            engineParams ep = new engineParams();
            A.CallTo(() => ep.listner.Dispose()).Throws(new Exception("Listner exception"));

            TestHelpersNet.CatchExpected(50056, "SpStateMachineEngine", "Start", "Attempting to use Disposed Object", () => {
                SpStateMachineEngine engine = new SpStateMachineEngine(ep.listner, ep.st, ep.be, ep.sm, ep.tm);
                Console.WriteLine("Test: Disposing");
                engine.Dispose();
                Thread.Sleep(500); // Nothing stopping the thead internaly with mocks
                engine.Start();

            });
        }

        #endregion

        #region Stop

        [Test]
        public void _50057_StopDisposed() {
            engineParams ep = new engineParams();
            A.CallTo(() => ep.listner.Dispose()).Throws(new Exception("Listner exception"));

            TestHelpersNet.CatchExpected(50057, "SpStateMachineEngine", "Stop", "Attempting to use Disposed Object", () => {
                SpStateMachineEngine engine = new SpStateMachineEngine(ep.listner, ep.st, ep.be, ep.sm, ep.tm);
                Console.WriteLine("Test: Disposing");
                engine.Dispose();
                Thread.Sleep(500); // Nothing stopping the thead internaly with mocks
                engine.Stop();

            });
        }

        #endregion

        #region Dispose

        [Test]
        public void _0_Dispose_MultiDisposeSafe() {
            engineParams ep = new engineParams();
            A.CallTo(() => ep.listner.Dispose()).Throws(new Exception("Listner exception"));

            TestHelpersNet.CatchUnexpected(() => {
                SpStateMachineEngine engine = new SpStateMachineEngine(ep.listner, ep.st, ep.be, ep.sm, ep.tm);
                Console.WriteLine("Test: Disposing");
                engine.Dispose();
                engine.Dispose();
                engine.Dispose();
                engine.Dispose();
                engine.Dispose();
                Thread.Sleep(500); // Nothing stopping the thead internaly with mocks
                Console.WriteLine("Test: Finished Disposing");
            });

            this.logReader.Validate(50060, "SpStateMachineEngine", "DisposeObject", "Error Disposing Object:msgListner");
        }

        #endregion

        #region DisposeObject

        [Test]
        public void _50060_DisposeObject_ErrorDisposingInternalObjects() {
            engineParams ep = new engineParams();
            A.CallTo(() => ep.listner.Dispose()).Throws(() => new Exception("Listner exception"));
            TestHelpersNet.CatchUnexpected(() => {
                SpStateMachineEngine engine = new SpStateMachineEngine(ep.listner, ep.st, ep.be, ep.sm, ep.tm);
                Console.WriteLine("Test: Disposing");
                engine.Dispose();
                Thread.Sleep(500); // Nothing stopping the thead internaly with mocks
                Console.WriteLine("Test: Finished Disposing");
            });

            this.logReader.Validate(50060, "SpStateMachineEngine", "DisposeObject", "Error Disposing Object:msgListner");
        }


        [Test]
        public void _0_DisposeObject_Success() {
            TestHelpersNet.CatchUnexpected(() => {
                SpStateMachineEngine engine = new SpStateMachineEngine(p.listner, p.st, p.be, p.sm, p.tm);
                engine.Dispose();
            });
        }

        #endregion

        #region Constructor

        [Test]
        public void _50050_SpStateMachineEngine_nullListner() {
            TestHelpersNet.CatchExpected(50050, "SpStateMachineEngine", ".ctor", "Null msgListner Argument", () => {
                SpStateMachineEngine engine = new SpStateMachineEngine(null, p.st, p.be, p.sm, p.tm);
                engine.Dispose();
            });

            //this.logReader.Validate(50060, "SpStateMachineEngine", "DisposeObject", "Error Disposing Object:msgListner");
        }

        [Test]
        public void _50051_SpStateMachineEngine_nullStore() {
            TestHelpersNet.CatchExpected(50051, "SpStateMachineEngine", ".ctor", "Null msgStore Argument", () => {
                SpStateMachineEngine engine = new SpStateMachineEngine(p.listner, null, p.be, p.sm, p.tm);
                engine.Dispose();
            });
        }

        [Test]
        public void _50052_SpStateMachineEngine_nullBehavior() {
            TestHelpersNet.CatchExpected(50052, "SpStateMachineEngine", ".ctor", "Null eventBehavior Argument", () => {
                SpStateMachineEngine engine = new SpStateMachineEngine(p.listner, p.st, null, p.sm, p.tm);
                engine.Dispose();
            });
        }

        [Test]
        public void _50053_SpStateMachineEngine_nullStateMachine() {
            TestHelpersNet.CatchExpected(50053, "SpStateMachineEngine", ".ctor", "Null stateMachine Argument", () => {
                SpStateMachineEngine engine = new SpStateMachineEngine(p.listner, p.st, p.be, null, p.tm);
                engine.Dispose();
            });
        }

        [Test]
        public void _50054_SpStateMachineEngine_nullTimer() {
            TestHelpersNet.CatchExpected(50054, "SpStateMachineEngine", ".ctor", "Null timer Argument", () => {
                SpStateMachineEngine engine = new SpStateMachineEngine(p.listner, p.st, p.be, p.sm, null);
                engine.Dispose();
            });
        }

        #endregion


        #region DriverThread

        [Test]
        public void _50058_DriverThreadUnexpectedError() {
            engineParams ep = new engineParams();
            A.CallTo(() => ep.listner.Dispose()).Throws(new Exception("Listner exception"));
            A.CallTo(() => ep.be.WaitOnEvent()).Throws(() => new Exception("Behavior WaitOn Exception"));

            TestHelpersNet.CatchUnexpected(() => {
                SpStateMachineEngine engine = new SpStateMachineEngine(ep.listner, ep.st, ep.be, ep.sm, ep.tm);
                Console.WriteLine("Test: Disposing");
                engine.Dispose();
                Thread.Sleep(500); // Nothing stopping the thead internaly with mocks
            });
            // Need to give time for error to post from thread
            Thread.Sleep(100);
            this.logReader.Validate(50058, "SpStateMachineEngine", "DriverThread", "Behavior WaitOn Exception");
        }

        #endregion

    }
}
