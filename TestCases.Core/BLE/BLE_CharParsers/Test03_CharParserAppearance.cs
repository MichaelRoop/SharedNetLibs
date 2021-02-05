using BluetoothLE.Net.Parsers.Characteristics;
using NUnit.Framework;
using System;
using TestCases.Core.TestToolSet;

namespace TestCases.Core.BLE.BLE_CharParsers {

    [TestFixture]
    public class Test03_CharParserAppearance : TestCaseBase {

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
        public void Phone() { this.Parse(64, "64,0", "Phone"); }
        [Test]
        public void Computer() { this.Parse(128, "128,0", "Computer"); }
        [Test]
        public void GenericWatch() { this.Parse(192, "192,0", "watch"); }
        [Test]
        public void SportsWatch() { this.Parse(193, "192,1", "Sports watch"); }
        [Test]
        public void GenericDisplay() { this.Parse(320, "320,0", "Display"); }
        [Test]
        public void GenericRemoteControl() { this.Parse(384, "384,0", "Remote control"); }
        [Test]
        public void GenericEyeglasses() { this.Parse(448, "448,0", "Eyeglasses"); }
        [Test]
        public void GenericTag() { this.Parse(512, "512,0", "Tag"); }
        [Test]
        public void GenericKeyring() { this.Parse(576, "576,0", "Keyring"); }
        [Test]
        public void GenericMediaPlayer() { this.Parse(640, "640,0", "Media player"); }
        [Test]
        public void GenericBarcodeScanner() { this.Parse(704, "704,0", "Barcode scanner"); }
        [Test]
        public void GenericThermometerGeneric() { this.Parse(768, "768,0", "Thermometer"); }
        [Test]
        public void ThermometerEar() { this.Parse(769, "768,1", "Ear Thermometer"); }


        #region Heart rate

        [Test]
        public void HeartRateSensor() {
            this.Parse(833, "832,1", "Parse Heart Sensor (833) fail");
        }

        [Test]
        public void BloodPressureGeneric() {
            this.Parse(896, "896,0", "Parse blood pressure generic Sensor (896) fail");
        }

        #endregion

        #region Blood pressure

        [Test]
        public void BloodPressureArm() {
            this.Parse(897, "896,1", "Parse blood pressure Arm Sensor (897) fail");
        }

        [Test]
        public void BloodPressureWrist() {
            this.Parse(898, "896,2", "Parse blood pressure wrist  Sensor (898) fail");
        }

        #endregion

        #region Human Interface

        [Test]
        public void HID() { this.Parse(960, "960,0", "HID"); }
        [Test]
        public void Keyboard() { this.Parse(961, "960,1", "Keyboard"); }
        [Test]
        public void Mouse() { this.Parse(962, "960,2", "Mouse"); }
        [Test]
        public void Joystick() { this.Parse(963, "960,3", "Joystick"); }
        [Test]
        public void Gamepad() { this.Parse(964, "960,4", "Gamepad"); }
        [Test]
        public void DigitizerTablet() { this.Parse(965, "960,5", "Digitizer Tablet"); }
        [Test]
        public void CardReader() { this.Parse(966, "960,6", "Card Reader"); }
        [Test]
        public void DigitalPen() { this.Parse(967, "960,7", "Digital Pen"); }
        [Test]
        public void BarcodeScanner() { this.Parse(968, "960,8", "Barcode scanner"); }

        #endregion

        #region Walking sensor

        [Test]
        public void WalkingSensor() { this.Parse(1088, "1088,0", "Walking Sensor"); }
        [Test]
        public void WalkingSensorInShoe() { this.Parse(1089, "1088,1", "Walking Sensor"); }
        [Test]
        public void WalkingSensorOnShoe() { this.Parse(1090, "1088,2", "Walking Sensor"); }
        [Test]
        public void WalkingSensorOnHip() { this.Parse(1091, "1088,3", "Walking Sensor"); }

        #endregion

        #region Cycling

        [Test]
        public void Cycling() { this.Parse(1152, "1152,0", "Cycling "); }
        [Test]
        public void CyclingComputer() { this.Parse(1153, "1152,1", "Cycling Computer"); }
        [Test]
        public void CyclingSpeed() { this.Parse(1154, "1152,2", "Cycling Speed"); }
        [Test]
        public void CyclingCadence() { this.Parse(1155, "1152,3", "Cycling Cadence"); }
        [Test]
        public void CyclingPower() { this.Parse(1156, "1152,4", "Cycling Power"); }
        [Test]
        public void CyclingSpeedAndCadence() { this.Parse(1157, "1152,5", "Cycling Speed and Cadence"); }

        #endregion

        #region Control

        [Test]
        public void Control() { this.Parse(1216, "1216,0", "Control"); }
        [Test]
        public void ControlSwitch() { this.Parse(1217, "1216,1", "Control Switch"); }
        [Test]
        public void ControlMultiSwitch() { this.Parse(1218, "1216,2", "Control Multi switch"); }
        [Test]
        public void ControlButton() { this.Parse(1219, "1216,3", "Control button"); }
        [Test]
        public void ControlSlider() { this.Parse(1220, "1216,4", "Control slider"); }
        [Test]
        public void ControlRotary() { this.Parse(1221, "1216,5", "Control rotary"); }
        [Test]
        public void ControlTouchPanel() { this.Parse(1222, "1216,6", "Control touch panel"); }

        #endregion

        #region Network device

        [Test]
        public void NetworkDevice() { this.Parse(1280, "1280,0", "Network device "); }
        [Test]
        public void NetworkDeviceAccessPoint() { this.Parse(1281, "1280,1", "Network device Access point"); }

        #endregion

        //[Test]
        //public void CC() { this.Parse(1, ",0", ""); }





        #region Private

        private void Parse(ushort value, string expected, string err) {
            TestHelpersNet.CatchUnexpected(() => {
                CharParser_Appearance b = new CharParser_Appearance();
                byte[] data = BitConverter.GetBytes((ushort)value);
                string result = b.Parse(data);
                Assert.AreEqual(expected, result, err);
            });
        }

        #endregion




    }
}
