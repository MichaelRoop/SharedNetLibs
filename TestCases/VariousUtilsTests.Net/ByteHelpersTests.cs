using CommunicationStack.Net.Stacks;
using LogUtils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VariousUtils;

namespace TestCases.VariousUtilsTests.Net {

    [TestFixture]
    public class ByteHelpersTests :TestCaseBase {

        byte[] newLine = "\n".ToAsciiByteArray();
        byte[] carReturn = "\r".ToAsciiByteArray();
        byte[] crln = "\r\n".ToAsciiByteArray();
        byte[] crlntab = "\r\n\t".ToAsciiByteArray();


        #region Setup

        [OneTimeSetUp]
        public void TestSetSetup() {
            this.OneTimeSetup();
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
        public void xBytePatternTests() {
            TestHelpersNet.CatchUnexpected(() => {
                byte[] buff = new byte[1000];
                int inPos = 0;
                // Single terminator pattern
                byte[] txt = "This".ToAsciiByteArray();
                Array.Copy(txt, buff, txt.Length);
                inPos = txt.Length;
                Array.Copy(carReturn, 0, buff, inPos, carReturn.Length);
                inPos += carReturn.Length;
                //Assert.AreEqual(4, ByteHelpers.FindFirstBytePatternPos(buff, inPos, carReturn));

                txt = "is".ToAsciiByteArray();
                Array.Copy(txt, 0, buff, inPos, txt.Length);
                inPos += txt.Length;
                Array.Copy(crlntab, 0, buff, inPos, crlntab.Length);
                inPos += crlntab.Length;
                //Assert.AreEqual(8, ByteHelpers.FindFirstBytePatternPos(buff, inPos, carReturn));

                txt = "crazy".ToAsciiByteArray();
                Array.Copy(txt, 0, buff, inPos, txt.Length);
                inPos += txt.Length;
                Array.Copy(crln, 0, buff, inPos, crln.Length);
                inPos += crln.Length;

                int totalLen = inPos;

                // 0123 456 7 8 901234 5 6
                // This\ris\r\n\tcrazy\r\n
                //      4   7

                inPos = ByteHelpers.FindFirstBytePatternPos(buff, carReturn, totalLen);
                Assert.AreEqual(4, inPos);

                inPos = ByteHelpers.FindFirstBytePatternPos(buff, crlntab, totalLen);
                Assert.AreEqual(7, inPos);

                // this will fail at 15 since it will fire on the crln at pos 7 since
                // the buffer was not purged
                //inPos = ByteHelpers.FindFirstBytePatternPos(buff, totalLen, crln);
                //Assert.AreEqual(15, inPos);

                double x = 0;
                for (int i = 0; i< 100; i++) {
                    Log.Info("DFDF", "sdfds", "Msg");
                    x++;
                }



            });
        }


        [Test]
        public void ByteFifoTests() {
            TestHelpersNet.CatchUnexpected(() => {
                byte[] buff = new byte[1000];
                int inPos = 0;

                // First
                buff.FifoPush("This".ToAsciiByteArray(), ref inPos);
                buff.FifoPush(" is ".ToAsciiByteArray(), ref inPos);
                buff.FifoPush("a new mes".ToAsciiByteArray(), ref inPos);
                buff.FifoPush("sage".ToAsciiByteArray(), ref inPos);
                buff.FifoPush(crln, ref inPos);

                // Second
                buff.FifoPush("Ano".ToAsciiByteArray(), ref inPos);
                buff.FifoPush("ther thin".ToAsciiByteArray(), ref inPos);
                buff.FifoPush("g".ToAsciiByteArray(), ref inPos);
                buff.FifoPush(crln, ref inPos);

                // Third
                buff.FifoPush("A ".ToAsciiByteArray(), ref inPos);
                buff.FifoPush("third".ToAsciiByteArray(), ref inPos);
                buff.FifoPush(" way".ToAsciiByteArray(), ref inPos);
                buff.FifoPush(crln, ref inPos);

                // First
                byte[] expected = "This is a new message".ToAsciiByteArray();
                byte[] actual = buff.FifoPop(crln, ref inPos);
                string e = expected.ToAsciiString();
                string a = actual.ToAsciiString();
                Log.Error(9999, () => string.Format("Expected: {0}", expected.ToAsciiString()));
                Log.Error(9999, () => string.Format("   Actual {0}", actual.ToAsciiString()));
                Assert.AreEqual(expected, actual);

                // Second
                expected = "Another thing".ToAsciiByteArray();
                actual = buff.FifoPop(crln, ref inPos);
                e = expected.ToAsciiString();
                a = actual.ToAsciiString();
                Log.Error(9999, "blipo.....");
                Log.Error(9999, () => string.Format("Expected: {0}", expected.ToAsciiString()));
                Log.Error(9999, () => string.Format("   Actual {0}", actual.ToAsciiString()));
                Assert.AreEqual(expected, actual);

                // third
                expected = "A third way".ToAsciiByteArray();
                actual = buff.FifoPop(crln, ref inPos);
                e = expected.ToAsciiString();
                a = actual.ToAsciiString();
                Log.Error(9999, "blipo.....");
                Log.Error(9999, () => string.Format("Expected: {0}", expected.ToAsciiString()));
                Log.Error(9999, () => string.Format("   Actual {0}", actual.ToAsciiString()));
                Assert.AreEqual(expected, actual);


                actual = buff.FifoPop(crln, ref inPos);
                Assert.AreEqual(0, actual.Length);
                Assert.AreEqual(0, inPos);



                Debug.WriteLine("sdflksdjfklsdjfklsdjfkls");

                //int xxx = 10;

                //System.Threading.Thread.Sleep(2000);

                //// Single terminator pattern
                //byte[] txt = "This".ToAsciiByteArray();
                //Array.Copy(txt, buff, txt.Length);
                //inPos = txt.Length;
                //Array.Copy(carReturn, 0, buff, inPos, carReturn.Length);
                //inPos += carReturn.Length;
                ////Assert.AreEqual(4, ByteHelpers.FindFirstBytePatternPos(buff, inPos, carReturn));

                //txt = "is".ToAsciiByteArray();
                //Array.Copy(txt, 0, buff, inPos, txt.Length);
                //inPos += txt.Length;
                //Array.Copy(crlntab, 0, buff, inPos, crlntab.Length);
                //inPos += crlntab.Length;
                ////Assert.AreEqual(8, ByteHelpers.FindFirstBytePatternPos(buff, inPos, carReturn));

                //txt = "crazy".ToAsciiByteArray();
                //Array.Copy(txt, 0, buff, inPos, txt.Length);
                //inPos += txt.Length;
                //Array.Copy(crln, 0, buff, inPos, crln.Length);
                //inPos += crln.Length;

                //int totalLen = inPos;

                //// 0123 456 7 8 901234 5 6
                //// This\ris\r\n\tcrazy\r\n
                ////      4   7

                //inPos = ByteHelpers.FindFirstBytePatternPos(buff, carReturn, totalLen);
                //Assert.AreEqual(4, inPos);

                //inPos = ByteHelpers.FindFirstBytePatternPos(buff, crlntab, totalLen);
                //Assert.AreEqual(7, inPos);

                //// this will fail at 15 since it will fire on the crln at pos 7 since
                //// the buffer was not purged
                ////inPos = ByteHelpers.FindFirstBytePatternPos(buff, totalLen, crln);
                ////Assert.AreEqual(15, inPos);


            });
        }


        [Test]
        public void ByteQueueTests() {
            CommCharInByteQueue q = new CommCharInByteQueue(crln);
            int count = 0;
            byte[] msg = new byte[0];
            q.MsgReceived += (sender, data) => {
                Log.Info("***", "***", () => string.Format("data:{0}", data));
                count++;
                msg = data;
            };

            q.AddBytes("This".ToAsciiByteArray());
            Assert.AreEqual(0, count, "1");
            q.AddBytes(" is ".ToAsciiByteArray());
            Assert.AreEqual(0, count, "2");
            q.AddBytes("a new mes".ToAsciiByteArray());
            Assert.AreEqual(0, count, "3");
            q.AddBytes("sage".ToAsciiByteArray());
            Assert.AreEqual(0, count, "4");
            q.AddBytes(crln);
            Assert.AreEqual(1, count, "1");
            Assert.AreEqual(21, msg.Length);
            byte[] expected = "This is a new message".ToAsciiByteArray();
            Assert.AreEqual(expected, msg, "Message contents");
            count = 0;
            msg = new byte[0];

            q.AddBytes(crln);
            Assert.AreEqual(0, count, "Should not have msg with only terminator pushed");




        }



        //TestHelpersNet.CatchUnexpected(() => {
        //    });


    }
}
