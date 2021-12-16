using BluetoothLE.Net.Enumerations;
using BluetoothLE.Net.Parsers.Descriptor;
using NUnit.Framework;
using TestCaseSupport.Core;
using VariousUtils.Net;

namespace TestCases.Core.BLE.BLE_DescParsers {

    [TestFixture]
    public class Test02_MultibleParsersValidData : TestCaseBase {

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
        public void AggregateFormat_ParseValid() {
            TestHelpers.CatchUnexpected(() => {
                DescParser_CharacteristicAggregateFormat parser = new ();
                List<ushort> attributes = new ();
                byte[] data = new byte[10 * sizeof(ushort)];
                int pos = 0;
                for (ushort i = 0; i < 10; i++) {
                    i.WriteToBuffer(data, ref pos);
                }
                parser.Parse(data);
                Assert.AreEqual(10, parser.AttributeHandles.Count);
                for (ushort i = 0; i < 10; i++) {
                    Assert.AreEqual(i, parser.AttributeHandles[i]);
                }
                //Assert.True(parser is DescParser_CharacteristicAggregateFormat);
            });
        }


        [Test]
        public void ExtendedProperties_ParseValid() {
            TestHelpers.CatchUnexpected(() => {
                DescParser_CharacteristicExtendedProperties parser = new ();
                //Assert.True(parser is DescParser_CharacteristicExtendedProperties);

                int pos = 0;
                ushort value = 0;
                byte[] data = new byte[sizeof(ushort)];
                value.WriteToBuffer(data, ref pos);
                parser.Parse(data);
                Assert.AreEqual(EnabledDisabled.Disabled, parser.ReliableWrite);
                Assert.AreEqual(EnabledDisabled.Disabled, parser.ReliableAuxiliary);

                // set first bit reliable write
                pos = 0;
                value = 1;
                value.WriteToBuffer(data, ref pos);
                parser.Parse(data);
                Assert.AreEqual(EnabledDisabled.Enabled, parser.ReliableWrite);
                Assert.AreEqual(EnabledDisabled.Disabled, parser.ReliableAuxiliary);

                // set second bit reliable auxiliary
                pos = 0;
                value = 2;
                value.WriteToBuffer(data, ref pos);
                parser.Parse(data);
                Assert.AreEqual(EnabledDisabled.Disabled, parser.ReliableWrite);
                Assert.AreEqual(EnabledDisabled.Enabled, parser.ReliableAuxiliary);

                // set bit 1,2 both enabled
                pos = 0;
                value = 3;
                value.WriteToBuffer(data, ref pos);
                parser.Parse(data);
                Assert.AreEqual(EnabledDisabled.Enabled, parser.ReliableWrite);
                Assert.AreEqual(EnabledDisabled.Enabled, parser.ReliableAuxiliary);
            });
        }




        //TestHelpers.CatchUnexpected(() => {
        //    });



        //private static void TestExtendedProperties(
        //    DescParser_CharacteristicExtendedProperties parser,
        //    byte[] data,
        //    ushort value,
        //    EnabledDisabled write,
        //    EnabledDisabled aux) {
        //    int pos = 0;
        //    value.WriteToBuffer(data, ref pos);
        //    parser.Parse(data);
        //    Assert.AreEqual(EnabledDisabled.Enabled, parser.ReliableWrite);
        //    Assert.AreEqual(EnabledDisabled.Disabled, parser.ReliableAuxiliary);
        //}


    }
}
