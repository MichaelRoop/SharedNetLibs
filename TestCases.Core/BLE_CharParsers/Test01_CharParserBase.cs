using BluetoothLE.Net.Parsers.Characteristics;
using LogUtils.Net;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TestCases.Core.TestToolSet;

namespace TestCases.Core.BLE_CharParsers {

    [TestFixture]
    public class Test01_CharParserBase : TestCaseBase {

        ClassLog log = new ClassLog("Test01_CharParserBase");

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
            protected override bool DoParse(byte[] data) {
                throw new NotImplementedException();
            }

            protected override Type GetDerivedType() {
                throw new NotImplementedException();
            }

            public CharParserFailConstructor1() : base() { }
            public CharParserFailConstructor1(byte[] data) : base(data) { }

        }

        class CharParserFailConstructor2 : CharParserFailConstructor1 {
            protected override Type GetDerivedType() { return typeof(CharParserFailConstructor2); }
            public CharParserFailConstructor2() : base() { }
            public CharParserFailConstructor2(byte[] data) : base(data) { }
        }


        class CharParserDisplayStrFaile : CharParserFailConstructor2 {
            protected override bool DoParse(byte[] data) {
                return true;
            }
            protected override string GetDisplayString() {
                throw new NotImplementedException();
            }
            public CharParserDisplayStrFaile() : base() { }
            public CharParserDisplayStrFaile(byte[] data) : base(data) { }
        }

        class CharParserCopyRaw : CharParser_Base {
            protected override bool DoParse(byte[] data) { return true; }
            protected override Type GetDerivedType() { return typeof(CharParserCopyRaw); }
            public CharParserCopyRaw(byte[] data, int length) {
                this.CopyToRawData(data, length);
            }

        }

        #endregion

        //
        [Test]
        public void Err13601_GetDisplayStrException() {
            TestHelpersNet.CatchUnexpected(() => {
                CharParserDisplayStrFaile b = new CharParserDisplayStrFaile(new byte[5]);
                this.logReader.Validate(13601, "CharParser_Base", "DisplayString", "Failed On DoDisplayString");
            });
        }


        [Test]
        public void Err13605_ParseZeroLength() {
            TestHelpersNet.CatchUnexpected(() => {
                CharParser_BatteryLevel b = new CharParser_BatteryLevel(new byte[0]);
                this.logReader.Validate(13605, "CharParser_Base", "Parse", "byte[] is zero length");
            });
        }


        [Test]
        public void Err13606_FailParseNull() {
            TestHelpersNet.CatchUnexpected(() => {
                CharParser_BatteryLevel b = new CharParser_BatteryLevel(null);
                this.logReader.Validate(13606, "CharParser_Base", "Parse", "Raw byte[] is null");
            });
        }




        [Test]
        public void Err13607_FailParseException() {
            TestHelpersNet.CatchUnexpected(() => {
                byte[] blah = new byte[2];
                CharParserFailConstructor2 b = new CharParserFailConstructor2(blah);
                this.logReader.Validate(13607, "CharParser_Base", "Parse", "Failure on Parse");
            });
        }


        [Test]
        public void Err13610_FailOnConstruction() {
            TestHelpersNet.CatchExpected(13610, "CharParser_Base", ".ctor", "Failed on construction", () => {
                CharParserFailConstructor1 b = new CharParserFailConstructor1();
            });
        }

        [Test]
        public void Err13611_FailOnConstruction() {
            TestHelpersNet.CatchExpected(13611, "CharParser_Base", ".ctor", "Failed on construction", () => {
                CharParserFailConstructor1 b = new CharParserFailConstructor1(new byte[5]);
            });
        }


        [Test]
        public void Err13615_CopyRawLengthMismatch() {
            TestHelpersNet.CatchUnexpected(() => {
                byte[] data = new byte[2];
                CharParserCopyRaw b = new CharParserCopyRaw(data, 5);
                this.logReader.Validate(13615, "CharParser_Base", "CopyToRawData",
                    "Data length:2 smaller than requested:5 Data '0x00,0x00'");
            });
        }


        [Test]
        public void Err13616_CopyRawNull() {
            TestHelpersNet.CatchUnexpected(() => {
                CharParserCopyRaw b = new CharParserCopyRaw(null, 5);
                this.logReader.Validate(13616, "CharParser_Base", "CopyToRawData", "Raw byte[] is null");
            });
        }

        // 13617 cannot be tested. Generic catch in CopyRawData

    }
}
