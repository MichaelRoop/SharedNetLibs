using NUnit.Framework;
using SpStateMachine.Net.EventStores;
using SpStateMachine.Net.Interfaces;
using TestCases.SpStateMachineTests.TestImplementations;
using TestCases.SpStateMachineTests.TestImplementations.Messages;
using TestCaseSupport.Core;
using SpStateMachine.Net.Core;

namespace TestCases.SpStateMachineTests {

    [TestFixture]
    public class EventStoreTests {

        #region Data

        readonly HelperLogReader logReader = new ();

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
        
        #region Base 

        [Test]
        public void T0_Base_MutilDisposed() {
            TestHelpers.CatchUnexpected(() => {
                ISpEventStore d = new SimpleDequeEventStore(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick));
                d.Dispose();
                d.Dispose();
                d.Dispose();
            });
        }

        [Test]
        public void T50110_Base_Constructor_NullParam() {
            TestHelpers.CatchExpected(50110, "BaseEventStore", ".ctor", "Null defaultTick Argument", () => {
                ISpEventStore d = new SimpleDequeEventStore(null);
            });
        }

        [Test]
        public void T50111_Base_Add_Disposed() {
            TestHelpers.CatchExpected(50111, "BaseEventStore", "Add", "Attempting to use Disposed Object", () => {
                ISpEventStore d = new SimpleDequeEventStore(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick));
                d.Dispose();
                d.Add(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick));
            });
        }

        [Test]
        public void T50112_Base_Add_NullMsg() {
            TestHelpers.CatchExpected(50112, "BaseEventStore", "Add", "Null msg Argument", () => {
                ISpEventStore d = new SimpleDequeEventStore(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick));
                d.Add(null);
            });
        }

        [Test]
        public void T50113_Base_Get_Disposed() {
            TestHelpers.CatchExpected(50113, "BaseEventStore", "Get", "Attempting to use Disposed Object", () => {
                ISpEventStore d = new SimpleDequeEventStore(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick));
                d.Dispose();
                d.Get();
            });
        }
        
        #endregion

        #region SimpleDequeQueue

        [Test]
        public void T0_SimpleDequeQueue_Add() {
            TestHelpers.CatchUnexpected(() => {
                ISpEventStore d = new SimpleDequeEventStore(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick));
                d.Add(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick));
                d.Add(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick));
                d.Add(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick));
            });
        }


        [Test]
        public void T0_SimpleDequeQueue_AddSequencing() {
            ISpEventStore d;
            TestHelpers.CatchUnexpected(() => {
                d = new SimpleDequeEventStore(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick));
                d.Add(new MyBaseMsg(MyMsgType.DataStrMsg, MyMsgId.Abort));
                d.Add(new MyBaseMsg( MyMsgType.SimpleMsg,  MyMsgId.Start));
                d.Add(new MyBaseMsg(MyMsgType.DataStrMsg, MyMsgId.Stop));
                MsgEqual(new MyBaseMsg(MyMsgType.DataStrMsg, MyMsgId.Abort), d.Get());
                MsgEqual(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Start), d.Get());
                MsgEqual(new MyBaseMsg(MyMsgType.DataStrMsg, MyMsgId.Stop), d.Get());
                MsgEqual(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick), d.Get());
                TestHelpers.CatchUnexpected(d.Dispose);
            });

        }

        #endregion

        #region Priority Queue

        [Test]
        public void T0_PriorityEventStore_Add() {
            TestHelpers.CatchUnexpected(() => {
                ISpEventStore d = new SimpleDequeEventStore(
                    new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick));
                d.Add(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Start, SpEventPriority.Undefined));
                d.Add(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Stop, SpEventPriority.High));
                d.Add(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Abort, SpEventPriority.Normal));
                d.Add(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.ExitAborted, SpEventPriority.Low));
            });
        }
        
        [Test]
        public void T0_PriorityEventStore_AddSequence() {
            ISpEventStore? d = null;
            TestHelpers.CatchUnexpected(() => {
                // Note: This is the priority store, not the simple deque
                d = new PriorityEventStore(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick));
                d.Add(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Start, SpEventPriority.Low));
                d.Add(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Stop, SpEventPriority.Low));

                d.Add(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.StartGas, SpEventPriority.Normal));
                d.Add(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.StopGas, SpEventPriority.Normal));

                d.Add(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.StartHeater, SpEventPriority.High));
                d.Add(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.StopHeater, SpEventPriority.High));

                d.Add(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Abort, SpEventPriority.Urgent));
                d.Add(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.ExitAborted, SpEventPriority.Urgent));
            });
            Assert.NotNull(d);
            if (d == null) {
                return;
            }

            // Validate sequence by priority and sequence within priority

            MsgEqual(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Abort, SpEventPriority.Urgent), d.Get());
            MsgEqual(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.ExitAborted, SpEventPriority.Urgent), d.Get());

            MsgEqual(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.StartHeater, SpEventPriority.High), d.Get());
            MsgEqual(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.StopHeater, SpEventPriority.High), d.Get());

            MsgEqual(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.StartGas, SpEventPriority.Normal), d.Get());
            MsgEqual(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.StopGas, SpEventPriority.Normal), d.Get());

            MsgEqual(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Start, SpEventPriority.Low), d.Get());
            MsgEqual(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Stop, SpEventPriority.Low), d.Get());

            MsgEqual(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick, SpEventPriority.Normal), d.Get());

            TestHelpers.CatchUnexpected(() => {
                d.Dispose();
            });
        }


        [Test]
        public void T50150_PriorityEventStore_AddEvent_UnhandledPriority() {
            TestHelpers.CatchExpected(50150, "PriorityEventStore", "AddEvent", "The Priority Type 'Undefined' is not Handled", () => {
                ISpEventStore d = new PriorityEventStore(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick));
                d.Add(new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Start, SpEventPriority.Undefined));
            });
        }

        #endregion

        #region Private Methods

        private static void MsgEqual(ISpEventMessage expected, ISpEventMessage actual) {
            Assert.IsNotNull(actual, "Current message null");
            Assert.AreEqual(expected.EventId, actual.EventId, "Event Id Mismatch");
            Assert.AreEqual(expected.Priority, actual.Priority, "Priority Id Mismatch");
            Assert.AreEqual(expected.TypeId, actual.TypeId, "Type Id Mismatch");
        }
        
        #endregion
    }
}
