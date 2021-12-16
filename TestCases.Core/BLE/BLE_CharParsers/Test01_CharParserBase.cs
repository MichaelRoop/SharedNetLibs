using BluetoothLE.Net.Parsers.Characteristics;
using LogUtils.Net;
using NUnit.Framework;
using TestCaseSupport.Core;

namespace TestCases.Core.BLE.BLE_CharParsers {

    [TestFixture]
    public class Test01_CharParserBase : TestCaseBase {

        //private readonly ClassLog log = new ("Test01_CharParserBase");

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

        #region Test classes

        class CharParserFailConstructor1 : CharParser_Base {

            public override int RequiredBytes { get; protected set; } = 5;

            protected override void DoParse(byte[] data) {
                throw new NotImplementedException();
            }

            public CharParserFailConstructor1() : base() { }

        }

        class CharParserFailConstructor2 : CharParserFailConstructor1 {
            public override int RequiredBytes { get; protected set; } = 0;
            public CharParserFailConstructor2() : base() { }
        }


        class CharParserDisplayStrFaile : CharParserFailConstructor2 {
            public override int RequiredBytes { get; protected set; } = 0;
            protected override void DoParse(byte[] data) {
            }
            public CharParserDisplayStrFaile() : base() { }
        }

        class CharParserCopyRaw : CharParser_Base {
            public override int RequiredBytes { get; protected set; } = 5;

            protected override void DoParse(byte[] data) { }


            //public CharParserCopyRaw(byte[] data, int length) {
            //    this.RequiredBytes = length;
            //    //this.CopyToRawData(data);

            //}

        }

        #endregion

        [Test]
        public void Err13618_ParseZeroLength() {
            TestHelpers.CatchUnexpected(() => {
                CharParser_BatteryLevel bl = new ();
                bl.Parse(Array.Empty<byte>());
                this.logReader.Validate(13618, "BLEParserBase", "CopyToRawData", "byte[] is zero length");
            });
        }


        [Test]
        public void Err13616_FailParseNull() {
            TestHelpers.CatchUnexpected(() => {
                CharParser_BatteryLevel bl = new ();
                bl.Parse(null);
                this.logReader.Validate(13616, "BLEParserBase", "CopyToRawData", "Raw byte[] is null");
            });
        }




        [Test]
        public void Err13607_FailParseException() {
            TestHelpers.CatchUnexpected(() => {
                byte[] blah = new byte[5];
                CharParserFailConstructor1 c = new ();
                c.Parse(blah);
                this.logReader.Validate(13607, "BLEParserBase", "Parse", "Failure on Parse");
            });
        }


        [Test]
        public void Err13615_CopyRawLengthMismatch() {
            TestHelpers.CatchUnexpected(() => {
                byte[] data = new byte[2];
                //CharParserCopyRaw b = new CharParserCopyRaw(data, 5);
                CharParserCopyRaw b = new ();
                b.Parse(data);
                this.logReader.Validate(13615, "BLEParserBase", "CopyToRawData",
                    "Data length:2 smaller than requested:5 Data '0x00,0x00'");
            });
        }


        //[Test]
        //public void Err13616_CopyRawNull() {
        //    TestHelpers.CatchUnexpected(() => {
        //        //CharParserCopyRaw b = new CharParserCopyRaw(null, 5);
        //        CharParserCopyRaw b = new CharParserCopyRaw();
        //        b.Parse(null);
        //        this.logReader.Validate(13616, "CharParser_Base", "CopyToRawData", "Raw byte[] is null");
        //    });
        //}

        // 13617 cannot be tested. Generic catch in CopyRawData

    }
}
