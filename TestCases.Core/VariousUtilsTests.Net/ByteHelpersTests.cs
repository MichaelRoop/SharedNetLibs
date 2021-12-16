using CommunicationStack.Net.Stacks;
using LogUtils.Net;
using NUnit.Framework;
using System.Diagnostics;
using System.Text;
using TestCaseSupport.Core;
using VariousUtils.Net;

namespace TestCases.VariousUtilsTests.Net {

    [TestFixture]
    public class ByteHelpersTests : TestCaseBase {

        //private readonly byte[] newLine = "\n".ToAsciiByteArray();
        private readonly byte[] carReturn = "\r".ToAsciiByteArray();
        private readonly byte[] crln = "\r\n".ToAsciiByteArray();
        private readonly byte[] crlntab = "\r\n\t".ToAsciiByteArray();
        private readonly ClassLog log = new ("ByteHelpersTests");

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
        public void XBytePatternTests() {
            TestHelpers.CatchUnexpected(() => {
                this.log.InfoEntry("xBytePatternTests");

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

            });
        }


        [Test]
        public void ByteFifoTests() {
            TestHelpers.CatchUnexpected(() => {
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
            CommCharInByteQueue q = new (crln);
            int count = 0;
            byte[] msg = Array.Empty<byte>();
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
            msg = Array.Empty<byte>();

            q.AddBytes(crln);
            Assert.AreEqual(0, count, "Should not have msg with only terminator pushed");




        }



        [Test]
        public void PrintBytes() {
            TestHelpers.CatchUnexpected(() => {

                foreach (Terminator t in EnumHelpers.GetEnumList<Terminator>()) {
                    Debug.WriteLine("({0})Name: {1}   Hex:{2}   StrView:{3}   char:{4}",
                        ((byte)t).ToString("D2"), t.ToString().PadLeft(3, ' '), t.ToHexString(), t.ToStringCharDisplay(), t.ToStringChar().PadLeft(3, ' '));

                    //Log.Info("***", "***", () => string.Format("({0})Name: {1} Hex:{2} Str:{3}",
                    //    ((byte)t).ToString("D2"), t.ToString(), t.ToHexString().PadLeft(3, ' '), t.ToStringChar()));
                }


            });
        }




        [Test]
        public void BitMaskingTest() {
            TestHelpers.CatchUnexpected(() => {
                byte[] data = new byte[] { 0xC1, 0x03 };
                uint raw = (uint)BitConverter.ToUInt16(data);
                //  6 bits = sub category - bits 0-5
                // 10 bits = category     - bits 6-15
                uint uCatMask = 65534; // 1111 1111 1100 0000 
                uint uSubMask = 63;    // 0000 0000 0011 1111
                StringBuilder sb = new ();
                sb.Append((raw & uCatMask)).Append(',').Append((raw & uSubMask));
                string val = sb.ToString();
                this.log.Info("BitMaskingTest", () => string.Format("{0} ({1})  from bytes {2}", val, raw, data.ToFormatedByteString()));
            });
        }



        //Appearance
        //iPad
        //0x80,0x02
        //1000 0000 0000 0010
        //gave 640,0
        //should have been: 512,2
        //spec 960 Generic Media Player

        //Keyboard
        //0xC1, 0x03
        //1100 0001 0000 0011
        //gave 961,0
        //Spec 960, 1 (concatenated 961)
        //should have been:772,3 xxxxx 960,0




        //TestHelpers.CatchUnexpected(() => {
        //    });


    }
}
