using NUnit.Framework;
using SpStateMachine.Net.Interfaces;
using TestCases.SpStateMachineTests.TestImplementations;
using TestCases.SpStateMachineTests.TestImplementations.Messages;
using TestCaseSupport.Core;

namespace TestCases.SpStateMachineTests {

    [TestFixture]
    public class MessagesTests {

        #region Data

        HelperLogReader logReader = new ();

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
        
        [Test]
        public void _0_SpBaseResponseCopyOverGuid() {
            TestHelpers.CatchUnexpected(() => {
                ISpEventMessage msg = new MyBaseMsg(MyMsgType.SimpleMsg, MyMsgId.Tick);
                ISpEventMessage response = new MyBaseResponse(MyMsgType.SimpleMsg, msg, MyReturnCode.Success, "");
                Assert.AreEqual(msg.Uid, response.Uid, "Guid mismatch between message and response");
            });
        }

    }
}
