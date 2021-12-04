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

    public class smDerivedManagedFail : SpMachine<IDisposable,MyMsgId> {
        public smDerivedManagedFail(IDisposable wo, ISpState<MyMsgId> state)
            : base(wo, state) {
        }
        protected override void  DisposeManagedResources() {
            throw new Exception("Managed Dispose Exception");
        }
    }

    public class smDerivedNativeFail : SpMachine<IDisposable, MyMsgId> {
        public smDerivedNativeFail(IDisposable wo, ISpState<MyMsgId> state)
            : base(wo, state) {
        }
        protected override void DisposeNativeResources() {
            throw new Exception("Native Dispose Exception");
        }
    }

    #endregion

    [TestFixture]
    public class SpStateMachineTests {

        #region Data

        HelperLogReader logReader = new HelperLogReader();

        public class smParams {
            public ISpState<MyMsgId> st { get; set; } = A.Fake<ISpState<MyMsgId>>();
            public IDisposable wo { get; set; } = A.Fake<IDisposable>();
        }

        smParams p = new smParams();

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
                ISpStateMachine sm = new SpMachine<IDisposable, MyMsgId>(p.wo, p.st);
                sm.Dispose();
                sm.Dispose();
                sm.Dispose();
            });
        }

        [Test]
        public void _50173_Dispose_ChildManagedDisposeFail() {
            TestHelpers.CatchExpected(50173, "SpMachine`2", "Dispose", "Managed Dispose Exception", () => {
                ISpStateMachine sm = new smDerivedManagedFail(p.wo, p.st);
                sm.Dispose();
            });
        }

        [Test]
        public void _50174_Dispose_ChildManagedDisposeFail() {
            TestHelpers.CatchExpected(50174, "SpMachine`2", "Dispose", "Native Dispose Exception", () => {
                ISpStateMachine sm = new smDerivedNativeFail(p.wo, p.st);
                sm.Dispose();
            });
        }
        
        [Test]
        public void _50175_Dispose_ManagedResources_Error() {
            smParams sp = new smParams();
            A.CallTo(() => sp.wo.Dispose()).Throws(() => new Exception("Wrapped Object Threw Exception on Dispose"));

            TestHelpers.CatchExpected(50175, "SpMachine`2", "DisposeManagedResources", "Wrapped Object Threw Exception on Dispose", () => {
                ISpStateMachine sm = new SpMachine<IDisposable,MyMsgId>(sp.wo, sp.st);
                sm.Dispose();
            });
        }

        #endregion

        #region Constructor

        [Test]
        public void _50170_Ctor_WrappedObject() {
            TestHelpers.CatchExpected(50170, "SpMachine`2", ".ctor", "Null wrappedObject Argument", () => {
                ISpStateMachine sm = new SpMachine<IDisposable,MyMsgId>(null, p.st);
                sm.Dispose();
            });
        }

        [Test]
        public void _50171_Ctor_NullState() {
            TestHelpers.CatchExpected(50171, "SpMachine`2", ".ctor", "Null state Argument", () => {
                ISpStateMachine sm = new SpMachine<IDisposable,MyMsgId>(p.wo, null);
                sm.Dispose();
            });
        }

        #endregion

        #region Tick

        [Test]
        public void _0_Tick_Ok() {
            smParams sp = new smParams();
            A.CallTo(() => sp.st.FullName).Returns("Main.FirstState.Init");
            A.CallTo(() => sp.st.OnEntry(null)).WithAnyArguments().Returns(
                 new SpStateTransition<MyMsgId>(
                     SpStateTransitionType.SameState, null, new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Start)));

            TestHelpers.CatchUnexpected(() => {
                ISpStateMachine sm = new SpMachine<IDisposable,MyMsgId>(sp.wo, sp.st);
                sm.Tick(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick));
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
            TestHelpers.CatchExpected(50172, "SpMachine`2", "Tick", "Null msg Argument", () => {
                ISpStateMachine sm = new SpMachine<IDisposable,MyMsgId>(p.wo, p.st);
                sm.Tick(null);
            });
        }


        [Test]
        public void _50176_Tick_Disposed() {
            TestHelpers.CatchExpected(50176, "SpMachine`2", "Tick", "Attempting to use Disposed Object", () => {
                ISpStateMachine sm = new SpMachine<IDisposable,MyMsgId>(p.wo, p.st);
                sm.Dispose();
                sm.Tick(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick));
            });
        }

        #endregion

    }

}
