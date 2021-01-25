using System;
using System.Globalization;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Types {

    /// <summary>Parse out bytes to display string and double with 2 decimal</summary>
    public class TypeParserUint16Exp2 : BLEParserBase {

        public double Value { get; private set; }

        public override int RequiredBytes { get; protected set; } = UINT16_LEN;

        protected override void DoParse(byte[] data) {
            // Each unit is 0.01 degree celcius - multiply to get real value with 2 decimal exponent 
            this.Value = Math.Round((double)(data.ToInt16(0) * 0.01), 2);
            this.DisplayString = this.Value.ToString("#######0.00", CultureInfo.CurrentCulture);
        }

        protected override void ResetMembers() {
            this.Value = 0;
            base.ResetMembers();
        }

    }
}
