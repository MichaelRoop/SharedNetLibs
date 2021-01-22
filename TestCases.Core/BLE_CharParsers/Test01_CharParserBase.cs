﻿using BluetoothLE.Net.Parsers.Characteristics;
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

            public override int RequiredBytes { get; protected set; } = 5;

            protected override bool DoParse(byte[] data) {
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
            protected override bool DoParse(byte[] data) {
                return true;
            }
            public CharParserDisplayStrFaile() : base() { }
        }

        class CharParserCopyRaw : CharParser_Base {
            public override int RequiredBytes { get; protected set; } = 0;

            protected override bool DoParse(byte[] data) { return true; }
            public CharParserCopyRaw(byte[] data, int length) {
                this.RequiredBytes = length;
                this.CopyToRawData(data);
            }

        }

        #endregion

        [Test]
        public void Err13605_ParseZeroLength() {
            TestHelpersNet.CatchUnexpected(() => {
                CharParser_BatteryLevel bl = new CharParser_BatteryLevel();
                bl.Parse(new byte[0]);
                this.logReader.Validate(13605, "CharParser_Base", "Parse", "byte[] is zero length");
            });
        }


        [Test]
        public void Err13606_FailParseNull() {
            TestHelpersNet.CatchUnexpected(() => {
                CharParser_BatteryLevel bl = new CharParser_BatteryLevel();
                bl.Parse(null);
                this.logReader.Validate(13606, "CharParser_Base", "Parse", "Raw byte[] is null");
            });
        }




        [Test]
        public void Err13607_FailParseException() {
            TestHelpersNet.CatchUnexpected(() => {
                byte[] blah = new byte[2];
                CharParserFailConstructor1 c = new CharParserFailConstructor1();
                c.Parse(blah);
                this.logReader.Validate(13607, "CharParser_Base", "Parse", "Failure on Parse");
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
