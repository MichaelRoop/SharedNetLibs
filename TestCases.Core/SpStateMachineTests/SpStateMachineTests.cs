using NUnit.Framework;
using SpStateMachine.Net.Core;
using SpStateMachine.Net.Interfaces;
using System;
using TestCases.SpStateMachineTests.TestImplementations;
using TestCases.SpStateMachineTests.TestImplementations.Messages;
using TestCaseSupport.Core;
using FakeItEasy;

namespace TestCases.SpStateMachineTests {

    #region Internal Test Classes

    public class SmDerivedManagedFail(IDisposable wo, ISpState<MyMsgId> state) 
        : SpMachine<IDisposable,MyMsgId>(wo, state) {
        protected override void  DisposeManagedResources() {
            throw new Exception("Managed Dispose Exception");
        }
    }

    public class SmDerivedNativeFail(IDisposable wo, ISpState<MyMsgId> state) 
        : SpMachine<IDisposable, MyMsgId>(wo, state) {
        protected override void DisposeNativeResources() {
            throw new Exception("Native Dispose Exception");
        }
    }

    #endregion

    [TestFixture]
    public class SpStateMachineTests {

        #region Data

        readonly HelperLogReader logReader = new ();

        public class SmParams {
            public ISpState<MyMsgId> St { get; set; } = A.Fake<ISpState<MyMsgId>>();
            public IDisposable Wo { get; set; } = A.Fake<IDisposable>();
        }

        readonly SmParams p = new ();

        #endregion

        #region Setup

        [SetUp]
        public void TestSetup() {
            this.logReader.StartLogging();
        }

        [TearDown]
        public void TestTeardown() {
            this.logReader.StopLogging();
            System.Threading.Thread.Sleep(500);
            this.logReader.Clear();
        }

        #endregion

        #region Dispose

        [Test]
        public void _0_Dispose_Multi() {
            TestHelpers.CatchUnexpected(() => {
                SpMachine<IDisposable, MyMsgId> spMachine = new(p.Wo, p.St);
                ((ISpStateMachine)spMachine).Dispose();
                ((ISpStateMachine)spMachine).Dispose();
                ((ISpStateMachine)spMachine).Dispose();
            });
        }

        [Test]
        public void _50173_Dispose_ChildManagedDisposeFail() {
            _ = TestHelpers.CatchExpected(50173, "SpMachine`2", "Dispose", "Managed Dispose Exception", () => {
                SmDerivedManagedFail smDerivedManagedFail = new(p.Wo, p.St);
                ((ISpStateMachine)smDerivedManagedFail).Dispose();
            });
        }

        //[Test]
        //public void _50174_Dispose_ChildManagedDisposeFail() {
        //    TestHelpers.CatchExpected(50174, "SpMachine`2", "Dispose", "Native Dispose Exception", () => {
        //        ISpStateMachine sm = new smDerivedNativeFail(p.wo, p.st);
        //        sm.Dispose();
        //    });
        //}
        
        [Test]
        public void _50175_Dispose_ManagedResources_Error() {
            SmParams sp = new ();
            A.CallTo(() => sp.Wo.Dispose()).Throws(() => new Exception("Wrapped Object Threw Exception on Dispose"));

            _ = TestHelpers.CatchExpected(50175, "SpMachine`2", "DisposeManagedResources", "Wrapped Object Threw Exception on Dispose", () => {
                SpMachine<IDisposable, MyMsgId> spMachine = new(sp.Wo, sp.St);
                ((ISpStateMachine)spMachine).Dispose();
            });
        }

        #endregion

        #region Constructor

        [Test]
        public void _50170_Ctor_WrappedObject() {
            _ = TestHelpers.CatchExpected(50170, "SpMachine`2", ".ctor", "Null wrappedObject Argument", () => {
                SpMachine<IDisposable, MyMsgId> spMachine = new(null, p.St);
                ((ISpStateMachine)spMachine).Dispose();
            });
        }

        [Test]
        public void _50171_Ctor_NullState() {
            _ = TestHelpers.CatchExpected(50171, "SpMachine`2", ".ctor", "Null state Argument", () => {
                SpMachine<IDisposable, MyMsgId> spMachine = new(p.Wo, null);
                ((ISpStateMachine)spMachine).Dispose();
            });
        }

        #endregion

        #region Tick

        [Test]
        public void _0_Tick_Ok() {
            SmParams sp = new ();
            A.CallTo(() => sp.St.FullName).Returns("Main.FirstState.Init");
            A.CallTo(() => sp.St.OnEntry(null)).WithAnyArguments().Returns(
                 new SpStateTransition<MyMsgId>(
                     SpStateTransitionType.SameState, null, new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Start)));

            TestHelpers.CatchUnexpected(() => {
                SpMachine<IDisposable, MyMsgId> spMachine = new(sp.Wo, sp.St);
                ((ISpStateMachine)spMachine).Tick(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick));
            });
        }


        //// TODO work on this one to enable it
        //[Test]
        //public void _50177_Tick_StateNullTransition() {
        //    smParams sp = new smParams();
        //    A.CallTo(() => sp.st.FullName).Returns("Main.FirstState.Init");
        //    A.CallTo(() => sp.st.OnEntry(null)).WithAnyArguments().Returns(null);
        //    TestHelpers.CatchExpected(50177, "SpMachine`2", "Tick", "The State 'Main.FirstState.Init' OnEntry Returned a Null Transition", () => {
        //        ISpStateMachine sm = new SpMachine<IDisposable, MyMsgId>(sp.wo, sp.st);
        //        sm.Tick(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick));
        //    });
        //}


        [Test]
        public void _50172_Tick_NullMsg() {
            _ = TestHelpers.CatchExpected(50172, "SpMachine`2", "Tick", "Null msg Argument", () => {
                SpMachine<IDisposable, MyMsgId> spMachine = new(p.Wo, p.St);
                ((ISpStateMachine)spMachine).Tick(null);
            });
        }


        [Test]
        public void _50176_Tick_Disposed() {
            _ = TestHelpers.CatchExpected(50176, "SpMachine`2", "Tick", "Attempting to use Disposed Object", () => { 
                SpMachine<IDisposable, MyMsgId> spMachine = new(p.Wo, p.St); ((ISpStateMachine)spMachine).Dispose(); _ = ((ISpStateMachine)spMachine).Tick(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick)); 
            });
        }

        #endregion

    }

}
