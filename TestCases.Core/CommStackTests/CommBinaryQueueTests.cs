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

        int waitMs = 5;

        public class MyComm : ICommStackChannel {
            public event EventHandler<byte[]>? MsgReceivedEvent;

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
        public void BinaryMsg01_01PopFromQueue_WholePacketIn() {
            TestHelpers.CatchUnexpected(() => {
                bool gotIt = false;
                int length = 0;
                BinaryMsgUInt16 msg = new BinaryMsgUInt16(16, 32111);
                byte[] packet = msg.ToByteArray();
                this.stack.MsgReceived += (sender, data) => {
                    gotIt = true;
                    length = data.Length;
                };

                this.myComm.SendOutMsg(packet);
                // The send is on thread pool so give time to finish
                Thread.Sleep(waitMs);

                Assert.True(gotIt, "Did not get it");
                Assert.AreEqual(packet.Length, length, "Packet length");
            });
        }


        [Test]
        public void BinaryMsg01_02PopFromQueue_SplitPacketIn() {
            TestHelpers.CatchUnexpected(() => {

                bool gotIt = false;
                int length = 0;
                BinaryMsgUInt16 msg = new BinaryMsgUInt16(16, 32111);
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
                Thread.Sleep(waitMs);
                Assert.False(gotIt, "Only part 1");
                Assert.AreEqual(0, length, "Packet length should not be set");


                this.myComm.SendOutMsg(part2);
                Thread.Sleep(waitMs);
                Assert.True(gotIt, "Did not get it");
                Assert.AreEqual(packet.Length, length, "Packet length");
            });
        }


        [Test]
        public void BinaryMsg01_03PopFromQueue_SplitIntoBytesIn() {
            TestHelpers.CatchUnexpected(() => {
                bool gotIt = false;
                int length = 0;
                BinaryMsgUInt16 msg = new BinaryMsgUInt16(16, 32111);
                byte[] packet = msg.ToByteArray();
                this.stack.MsgReceived += (sender, data) => {
                    gotIt = true;
                    length = data.Length;
                };
                for (int i = 0; i < packet.Length; i++) {
                    byte[] part = new byte[1] { packet[i] };
                    this.myComm.SendOutMsg(part);
                    Thread.Sleep(waitMs);
                    if (i == (packet.Length - 1)) {
                        Assert.True(gotIt, "Should have gotten it");
                        Assert.AreEqual(packet.Length, length, "Packet length");
                    }
                    else {
                        Assert.False(gotIt, string.Format("packet[{0}] Should not have raised", i));
                     }
                }
            });
        }


        [Test]
        public void BinaryMsg01_04PopFromQueue_DoublePacketIn() {
            TestHelpers.CatchUnexpected(() => {
                BinaryMsgUInt16 msg1 = new BinaryMsgUInt16(16, 32111);
                byte[] packet1 = msg1.ToByteArray();
                BinaryMsgUInt16 msg2 = new BinaryMsgUInt16(16, 311);
                byte[] packet2 = msg2.ToByteArray();

                byte[] packet = new byte[packet1.Length + packet2.Length];
                Array.Copy(packet1, packet, packet1.Length);
                Array.Copy(packet2, 0, packet, packet1.Length, packet2.Length);
                int count = 0;
                this.stack.MsgReceived += (sender, data) => {
                    count++;
                };

                this.myComm.SendOutMsg(packet);
                // The send is on thread pool so give time to finish
                Thread.Sleep(waitMs);
                Assert.AreEqual(2, count, "Receive count");

                // Send other to make sure the queue still works
                this.myComm.SendOutMsg(packet1);
                // The send is on thread pool so give time to finish
                Thread.Sleep(waitMs);
                Assert.AreEqual(3, count, string.Format("Receive count"));

                // Send other to make sure the queue still works
                this.myComm.SendOutMsg(packet2);
                // The send is on thread pool so give time to finish
                Thread.Sleep(waitMs);
                Assert.AreEqual(4, count, string.Format("Receive count"));

            });
        }



        [Test]
        public void BinaryMsg02_01ObjectFromPacketBool() {
            TestHelpers.CatchUnexpected(() => {
                BinaryMsgBool msg = new BinaryMsgBool(22, true);
                byte[] packet = msg.ToByteArray();
                byte[] returnedPacket = this.GetQueuePopData(packet);
                BinaryMsgBool? received = returnedPacket.ToBoolMsg();
                this.ValidateReturnedObj(msg, received);
            });
        }

        [Test]
        public void BinaryMsg02_02ObjectFromPacketUInt8() {
            TestHelpers.CatchUnexpected(() => {
                BinaryMsgUInt8 msg = new BinaryMsgUInt8(16, 202);
                byte[] packet = msg.ToByteArray();
                byte[] returnedPacket = this.GetQueuePopData(packet);
                BinaryMsgUInt8? received = returnedPacket.ToUInt8Msg();
                this.ValidateReturnedObj(msg, received);
            });
        }

        [Test]
        public void BinaryMsg02_03ObjectFromPacketInt8() {
            TestHelpers.CatchUnexpected(() => {
                BinaryMsgInt8 msg = new BinaryMsgInt8(6, 122);
                byte[] packet = msg.ToByteArray();
                byte[] returnedPacket = this.GetQueuePopData(packet);
                BinaryMsgInt8? received = returnedPacket.ToInt8Msg();
                this.ValidateReturnedObj(msg, received);
            });
        }


        [Test]
        public void BinaryMsg02_04ObjectFromPacketUInt16() {
            TestHelpers.CatchUnexpected(() => {
                BinaryMsgUInt16 msg = new BinaryMsgUInt16(16, 32111);
                byte[] packet = msg.ToByteArray();
                byte[] returnedPacket = this.GetQueuePopData(packet);
                BinaryMsgUInt16? received = returnedPacket.ToUInt16Msg();
                this.ValidateReturnedObj(msg, received);
            });
        }

        [Test]
        public void BinaryMsg02_05ObjectFromPacketInt16() {
            TestHelpers.CatchUnexpected(() => {
                BinaryMsgInt16 msg = new BinaryMsgInt16(6, 3211);
                byte[] packet = msg.ToByteArray();
                byte[] returnedPacket = this.GetQueuePopData(packet);
                BinaryMsgInt16? received = returnedPacket.ToInt16Msg();
                this.ValidateReturnedObj(msg, received);
            });
        }

        [Test]
        public void BinaryMsg02_06ObjectFromPacketUInt32() {
            TestHelpers.CatchUnexpected(() => {
                BinaryMsgUInt32 msg = new BinaryMsgUInt32(1, 62111);
                byte[] packet = msg.ToByteArray();
                this.ValidateReturnedObj(msg, this.GetQueuePopData(packet).ToUInt32Msg());
            });
        }

        [Test]
        public void BinaryMsg02_07ObjectFromPacketInt32() {
            TestHelpers.CatchUnexpected(() => {
                BinaryMsgInt32 msg = new BinaryMsgInt32(144, 32111);
                byte[] packet = msg.ToByteArray();
                this.ValidateReturnedObj(msg, this.GetQueuePopData(packet).ToInt32Msg());
            });
        }


        [Test]
        public void BinaryMsg02_08ObjectFromPacketFloat32() {
            TestHelpers.CatchUnexpected(() => {
                BinaryMsgFloat32 msg = new BinaryMsgFloat32(144, 32111);
                byte[] packet = msg.ToByteArray();
                this.ValidateReturnedObj(msg, this.GetQueuePopData(packet).ToFloat32Msg());
            });
        }



        private void ValidateReturnedObj<T>(BinaryMsg<T> expected, BinaryMsg<T>? received) {
            TestHelpers.CatchUnexpected(() => {
#pragma warning disable CS8602,CS8602

                Assert.NotNull(received, "Failed to build object");
                Assert.AreEqual(expected.SOH, received.SOH);
                Assert.AreEqual(expected.STX, received.STX);
                Assert.AreEqual(expected.Size, received.Size);
                Assert.AreEqual(expected.Id, received.Id);
                Assert.AreEqual(expected.Value, received.Value);
                Assert.AreEqual(expected.ETX, received.ETX);
                Assert.AreEqual(expected.EOT, received.EOT);
#pragma warning restore CS8602,CS8602
            });
        }


        private byte[] GetQueuePopData(byte[] inPacket) {
            byte[] returnedPacket = new byte[0];
            TestHelpers.CatchUnexpected(() => {
                bool gotIt = false;
                int length = 0;
                this.stack.MsgReceived += (sender, data) => {
                    gotIt = true;
                    length = data.Length;
                    returnedPacket = data;
                };

                this.myComm.SendOutMsg(inPacket);
                // The send is on thread pool so give time to finish
                Thread.Sleep(waitMs);
                Assert.True(gotIt, "Did not get it");
                Assert.AreEqual(inPacket.Length, length, "Packet length");
            });
            return returnedPacket;
        }







    }
}
