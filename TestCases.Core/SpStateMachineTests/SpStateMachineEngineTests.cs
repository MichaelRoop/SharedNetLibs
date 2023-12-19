using NUnit.Framework;
using SpStateMachine.Net.Core;
using SpStateMachine.Net.Interfaces;
using System;
using System.Threading;
using TestCaseSupport.Core;
using FakeItEasy;

namespace TestCases.SpStateMachineTests {

    [TestFixture]
    public class SpStateMachineEngineTests {

        #region Data

        readonly HelperLogReader logReader = new ();

        public class EngineParams {
            public ISpEventListner Listner { get; set; } = A.Fake<ISpEventListner>();
            public ISpEventStore St { get; set; } = A.Fake<ISpEventStore>();
            public ISpBehaviorOnEvent Be { get; set; } = A.Fake<ISpBehaviorOnEvent>();
            public ISpStateMachine Sm { get; set; } = A.Fake<ISpStateMachine>();
            public ISpPeriodicTimer Tm { get; set; } = A.Fake<ISpPeriodicTimer>();
        }

        readonly EngineParams p = new ();

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
            EngineParams ep = new ();
            A.CallTo(() => ep.Listner.Dispose()).Throws(new Exception("Listner exception"));

            TestHelpers.CatchExpected(50056, "SpStateMachineEngine", "Start", "Attempting to use Disposed Object", () => {
                SpStateMachineEngine engine = new (ep.Listner, ep.St, ep.Be, ep.Sm, ep.Tm);
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
            EngineParams ep = new ();
            A.CallTo(() => ep.Listner.Dispose()).Throws(new Exception("Listner exception"));

            TestHelpers.CatchExpected(50057, "SpStateMachineEngine", "Stop", "Attempting to use Disposed Object", () => {
                SpStateMachineEngine engine = new (ep.Listner, ep.St, ep.Be, ep.Sm, ep.Tm);
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
            EngineParams ep = new ();
            A.CallTo(() => ep.Listner.Dispose()).Throws(new Exception("Listner exception"));

            TestHelpers.CatchUnexpected(() => {
                SpStateMachineEngine engine = new (ep.Listner, ep.St, ep.Be, ep.Sm, ep.Tm);
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
            EngineParams ep = new ();
            A.CallTo(() => ep.Listner.Dispose()).Throws(() => new Exception("Listner exception"));
            TestHelpers.CatchUnexpected(() => {
                SpStateMachineEngine engine = new (ep.Listner, ep.St, ep.Be, ep.Sm, ep.Tm);
                Console.WriteLine("Test: Disposing");
                engine.Dispose();
                Thread.Sleep(500); // Nothing stopping the thead internaly with mocks
                Console.WriteLine("Test: Finished Disposing");
            });

            this.logReader.Validate(50060, "SpStateMachineEngine", "DisposeObject", "Error Disposing Object:msgListner");
        }


        [Test]
        public void _0_DisposeObject_Success() {
            TestHelpers.CatchUnexpected(() => {
                SpStateMachineEngine engine = new (p.Listner, p.St, p.Be, p.Sm, p.Tm);
                engine.Dispose();
            });
        }

        #endregion

        #region Constructor

        [Test]
        public void _50050_SpStateMachineEngine_nullListner() {
            TestHelpers.CatchExpected(50050, "SpStateMachineEngine", ".ctor", "Null msgListner Argument", () => {
                SpStateMachineEngine engine = new (null, p.St, p.Be, p.Sm, p.Tm);
                engine.Dispose();
            });

            //this.logReader.Validate(50060, "SpStateMachineEngine", "DisposeObject", "Error Disposing Object:msgListner");
        }

        [Test]
        public void _50051_SpStateMachineEngine_nullStore() {
            TestHelpers.CatchExpected(50051, "SpStateMachineEngine", ".ctor", "Null msgStore Argument", () => {
                SpStateMachineEngine engine = new (p.Listner, null, p.Be, p.Sm, p.Tm);
                engine.Dispose();
            });
        }

        [Test]
        public void _50052_SpStateMachineEngine_nullBehavior() {
            TestHelpers.CatchExpected(50052, "SpStateMachineEngine", ".ctor", "Null eventBehavior Argument", () => {
                SpStateMachineEngine engine = new (p.Listner, p.St, null, p.Sm, p.Tm);
                engine.Dispose();
            });
        }

        [Test]
        public void _50053_SpStateMachineEngine_nullStateMachine() {
            TestHelpers.CatchExpected(50053, "SpStateMachineEngine", ".ctor", "Null stateMachine Argument", () => {
                SpStateMachineEngine engine = new (p.Listner, p.St, p.Be, null, p.Tm);
                engine.Dispose();
            });
        }

        [Test]
        public void _50054_SpStateMachineEngine_nullTimer() {
            TestHelpers.CatchExpected(50054, "SpStateMachineEngine", ".ctor", "Null timer Argument", () => {
                SpStateMachineEngine engine = new (p.Listner, p.St, p.Be, p.Sm, null);
                engine.Dispose();
            });
        }

        #endregion


        #region DriverThread

        [Test]
        public void _50058_DriverThreadUnexpectedError() {
            EngineParams ep = new ();
            A.CallTo(() => ep.Listner.Dispose()).Throws(new Exception("Listner exception"));
            A.CallTo(() => ep.Be.WaitOnEvent()).Throws(() => new Exception("Behavior WaitOn Exception"));

            TestHelpers.CatchUnexpected(() => {
                SpStateMachineEngine engine = new (ep.Listner, ep.St, ep.Be, ep.Sm, ep.Tm);
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
