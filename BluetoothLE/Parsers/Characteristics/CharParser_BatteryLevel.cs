using LogUtils.Net;
using System;

namespace BluetoothLE.Net.Parsers.Characteristics {
    public class CharParser_BatteryLevel : CharParser_Base {

        private readonly ClassLog log = new ClassLog("CharParser_BatteryLevel");
        private string level = "";


        public CharParser_BatteryLevel() : base() { }
        public CharParser_BatteryLevel(byte[] data) : base(data) { }


        protected override string DoDisplayString() {
            return this.level;
        }

        protected override bool DoParse(byte[] data) {
            if (this.CopyToRawData(data, data.Length)) {
                // Will be 1 in length
                int tmp = Convert.ToInt32(this.RawData[0].ToString());
                this.level = tmp.ToString();
                return true;
            }
            return false;
        }

        protected override Type GetDerivedType() {
            return this.GetType();
        }

        protected override void ResetMembers() {
            this.level = "";
        }
    }
}
