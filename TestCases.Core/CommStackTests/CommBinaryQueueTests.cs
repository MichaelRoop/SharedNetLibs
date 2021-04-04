using CommunicationStack.Net.interfaces;
using CommunicationStack.Net.Stacks;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using TestCaseSupport.Core;
using VariousUtils.Net;

namespace TestCases.Core.CommStackTests {

    [TestFixture]
    public class CommBinaryQueueTests : TestCaseBase {

        #region Data

        static byte SOH = 0x01;
        static byte STX = 0x02;
        static byte ETX = 0x03;
        static byte EOT = 0x04;

        byte[] startDelimiters = new byte[] { SOH, STX };
        byte[] endDelimiters = new byte[] { ETX, EOT};


        public class MyComm : ICommStackChannel {
            public event EventHandler<byte[]> MsgReceivedEvent;

            public bool SendOutMsg(byte[] msg) {
                // Just bounce it back for now
                this.MsgReceivedEvent?.Invoke(this, msg);
                return true;
            }

        }

        //MsgStruct testStruct = new MsgStruct();
        ICommStackLevel0 stack = new CommBinaryStackLevel0();
        MyComm myComm = new MyComm();

        #endregion

        #region Setup

        [OneTimeSetUp]
        public void TestSetSetup() {
            this.OneTimeSetup();
            stack.SetCommChannel(myComm);
            stack.InTerminators = this.startDelimiters;
            stack.OutTerminators = this.endDelimiters;
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
                UInt16 value = 32111;
                byte[] packet = this.InitMsg(value);
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
                UInt16 value = 32111;
                byte[] packet = this.InitMsg(value);
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







        #region Init msg 

        public enum MsgDataType : byte {
            tyepUndefined = 0,
            typeBool = 1,
            typeInt8 = 2,
            typeUInt8 = 3,
            typeInt16 = 4,
            typeUInt16 = 5,
            typeInt32 = 6,
            typeUInt32 = 7,
            typeFloat32 = 8,
            typeString = 9,
            typeInvalid = 10
        };



        private byte[] InitMsg(UInt16 value) {
            return this.CreatePacket(value.ToByteArray(), MsgDataType.typeUInt16);
        }


        byte GetPacketSize(byte payloadSize, MsgDataType dataType) {
            byte size = 0;
            SOH.AddSize(ref size);
            STX.AddSize(ref size);
            // use the byte size to increment the size field
            size.AddSize(ref size);
            ((byte)dataType).AddSize(ref size);
            ETX.AddSize(ref size);
            EOT.AddSize(ref size);
            size += payloadSize;
            return size;
        }


        byte[] CreatePacket(byte[] payload, MsgDataType dataType) {
            byte[] packet = new byte[this.GetPacketSize((byte)payload.Length, dataType)];
            int pos = 0;
            int sizePos = 0;
            SOH.WriteToBuffer(packet, ref pos);     // 0
            STX.WriteToBuffer(packet, ref pos);     // 1
            // Remember position to later write real size. Write dummy to increment
            sizePos = pos;
            ((byte)pos).WriteToBuffer(packet, ref pos);       // 2
            ((byte)dataType).WriteToBuffer(packet, ref pos);  //3
            payload.WriteToBuffer(packet, ref pos);           // For ushort 4,5
            ETX.WriteToBuffer(packet, ref pos);               // 6
            EOT.WriteToBuffer(packet, ref pos);               // 7
            // Now that we know the size, write it in
            packet[sizePos] = (byte)pos;
            return packet;
        }






        //private void InitMsg(bool value) {
        //    this.testStruct.dataType = (byte)MsgDataType.typeBool;
        //    this.testStruct.value.boolVal = value;
        //}

        //private void InitMsg(byte value) {
        //    this.testStruct.dataType = (byte)MsgDataType.typeUInt8;
        //    this.testStruct.value.uint8Val = value;
        //}

        //private void InitMsg(sbyte value) {
        //    this.testStruct.dataType = (byte)MsgDataType.typeInt8;
        //    this.testStruct.value.int8Val = value;
        //}

        //private void InitMsg(UInt16 value) {
        //    this.testStruct.dataType = (byte)MsgDataType.typeUInt16;
        //    this.testStruct.value.uint16Val = value;
        //}

        //private void InitMsg(Int16 value) {
        //    this.testStruct.dataType = (byte)MsgDataType.typeInt16;
        //    this.testStruct.value.int16Val = value;
        //}

        //private void InitMsg(UInt32 value) {
        //    this.testStruct.dataType = (byte)MsgDataType.typeUInt32;
        //    this.testStruct.value.uint32Val = value;
        //}

        //private void InitMsg(Int32 value) {
        //    this.testStruct.dataType = (byte)MsgDataType.typeInt32;
        //    this.testStruct.value.int32Val = value;
        //}

        //private void InitMsg(float value) {
        //    this.testStruct.dataType = (byte)MsgDataType.typeFloat32;
        //    this.testStruct.value.floatVal = value;
        //}


        //private void InitMsg(string value) {
        //    this.testStruct.dataType = (byte)MsgDataType.typeString;
        //    this.testStruct.value.stringVal = new char[32];
        //    for (int i = 0; i < 32; i++) {
        //        this.testStruct.value.stringVal[i] = '\0';
        //    }
        //    byte[] valueBytes = Encoding.ASCII.GetBytes(value);
        //    for (int i = 0; i < valueBytes.Length || i < 31; i++) {
        //        this.testStruct.value.stringVal[i] = (char)valueBytes[i];
        //    }
        //}



        #endregion


    }
}
