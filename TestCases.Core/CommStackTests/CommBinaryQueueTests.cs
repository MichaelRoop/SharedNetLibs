using CommunicationStack.Net.BinaryMsgs;
using CommunicationStack.Net.interfaces;
using CommunicationStack.Net.Stacks;
using NUnit.Framework;
using System;
using System.Threading;
using TestCaseSupport.Core;

namespace TestCases.Core.CommStackTests {

    [TestFixture]
    public class CommBinaryQueueTests : TestCaseBase {

        #region Data

        public class MyComm : ICommStackChannel {
            public event EventHandler<byte[]> MsgReceivedEvent;

            public bool SendOutMsg(byte[] msg) {
                // Just bounce it back for now
                this.MsgReceivedEvent?.Invoke(this, msg);
                return true;
            }

        }

        ICommStackLevel0 stack = new CommBinaryStackLevel0();
        MyComm myComm = new MyComm();

        #endregion

        #region Setup

        [OneTimeSetUp]
        public void TestSetSetup() {
            this.OneTimeSetup();
            stack.SetCommChannel(myComm);
            stack.InTerminators = BinaryMsgDefines.StartDelimiters;
            stack.OutTerminators = BinaryMsgDefines.EndDelimiters;
        }

        [OneTimeTearDown]
        public void TestSetTeardown() {
            this.OneTimeTeardown();
        }

        [SetUp]
        public void SetupEachTest() {
        }

        #endregion

        [Test]
        public void FullPacket01_01Whole() {
            TestHelpers.CatchUnexpected(() => {
                bool gotIt = false;
                int length = 0;
                BinaryMsgUint16 msg = new BinaryMsgUint16(16, 32111);
                byte[] packet = msg.ToByteArray();
                this.stack.MsgReceived += (sender, data)=> {
                    gotIt = true;
                    length = data.Length;
                };

                this.myComm.SendOutMsg(packet);
                // The send is on thread pool so give time to finish
                Thread.Sleep(100);

                Assert.True(gotIt, "Did not get it");
                Assert.AreEqual(packet.Length, length, "Packet length");
            });
        }

        private void Stack_MsgReceived(object sender, byte[] e) {
            throw new NotImplementedException();
        }

        [Test]
        public void FullPacket01_02Split() {
            TestHelpers.CatchUnexpected(() => {

                bool gotIt = false;
                int length = 0;
                BinaryMsgUint16 msg = new BinaryMsgUint16(16, 32111);
                byte[] packet = msg.ToByteArray();
                byte[] part1 = new byte[4];
                byte[] part2 = new byte[packet.Length - 4];
                Array.Copy(packet, part1, part1.Length);
                Array.Copy(packet, part1.Length, part2, 0, part2.Length);
                this.stack.MsgReceived += (sender, data) => {
                    gotIt = true;
                    length = data.Length;
                };
                this.myComm.SendOutMsg(part1);
                Thread.Sleep(100);
                Assert.False(gotIt, "Only part 1");
                Assert.AreEqual(0, length, "Packet length should not be set");


                this.myComm.SendOutMsg(part2);
                Thread.Sleep(100);
                Assert.True(gotIt, "Did not get it");
                Assert.AreEqual(packet.Length, length, "Packet length");
            });
        }

    }
}
