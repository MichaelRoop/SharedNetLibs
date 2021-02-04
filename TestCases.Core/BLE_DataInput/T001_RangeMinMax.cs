using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.Tools;
using LogUtils.Net;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using TestCases.Core.TestToolSet;

namespace TestCases.Core.BLE_DataInput {

    [TestFixture]
    public class T001_RangeMinMax : TestCaseBase {

        ClassLog log = new ClassLog("DescParserBaseTests");

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


        //[Test]
        //public void ByteNoPrecision() {
        //    TestHelpersNet.CatchUnexpected(() => {
        //        RangeMinMax r = new RangeMinMax(BLE_DataType.UInt_8bit, 0, 255);
        //        Assert.AreEqual((byte)0, r.Min);
        //        Assert.AreEqual((byte)255, r.Max);
        //        Assert.AreEqual("0", r.MinStr);
        //        Assert.AreEqual("255", r.MaxStr);
        //    });
        //}


        //[Test]
        //public void DoublePrecision() {
        //    TestHelpersNet.CatchUnexpected(() => {
        //        RangeMinMax r = new RangeMinMax(
        //            BLE_DataType.IEEE_754_64bit_floating_point, 
        //            Convert.ToDecimal(0.0), 
        //            Convert.ToDecimal(255000.23), 4);
        //        Assert.AreEqual(0, r.Min, "min");
        //        Assert.AreEqual(255000.23m, r.Max, "max");
        //        Assert.AreEqual("0", r.MinStr, "min str");
        //        Assert.AreEqual("255000.23", r.MaxStr, "max str");
        //    });
        //}


        //[Test]
        //public void DoubleNoPrecision() {
        //    TestHelpersNet.CatchUnexpected(() => {
        //        RangeMinMax r = new RangeMinMax(
        //            BLE_DataType.IEEE_754_64bit_floating_point,
        //            Convert.ToDecimal(0.0),
        //            Convert.ToDecimal(255000.23));
        //        Assert.AreEqual(0, r.Min, "min");
        //        Assert.AreEqual(255000m, r.Max, "max");
        //        Assert.AreEqual("0", r.MinStr, "min str");
        //        Assert.AreEqual("255000", r.MaxStr, "max str");
        //    });
        //}

        //[Test]
        //public void DoubleMinusNoPrecision() {
        //    TestHelpersNet.CatchUnexpected(() => {
        //        double min = -255000.23;
        //        double max = 255000.32;
        //        string minStr = min.ToString(CultureInfo.CurrentCulture);
        //        string maxStr = max.ToString(CultureInfo.CurrentCulture);

        //        RangeMinMax r = new RangeMinMax(
        //            BLE_DataType.IEEE_754_64bit_floating_point,
        //            Convert.ToDecimal(min),
        //            Convert.ToDecimal(max));
        //        Assert.AreEqual(min, r.Min, "min");
        //        Assert.AreEqual(max, r.Max, "max");
        //        Assert.AreEqual(minStr, r.MinStr, "min str");
        //        Assert.AreEqual(maxStr, r.MaxStr, "max str");


        //        //double d = -255000.23;
        //        //string str = d.ToString(CultureInfo.CurrentCulture);
        //        //Assert.AreEqual("-255000", r.MinStr, "min str DOUBLE");


        //    });
        //}

    }
}
