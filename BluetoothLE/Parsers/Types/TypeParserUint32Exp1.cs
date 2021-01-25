using System;
using System.Globalization;
using VariousUtils.Net;

namespace BluetoothLE.Net.Parsers.Types {

    public class TypeParserUint32Exp1 : BLEParserBase {
        
        public double Value { get; private set; }

        public override int RequiredBytes { get; protected set; } = UINT32_LEN;

        protected override void DoParse(byte[] data) {
            // Each unit is 0.1 - multiply to get real value with 1 decimal exponent 
            this.Value = Math.Round(((double)data.ToUint32(0) * 0.1), 1);
            this.DisplayString = this.Value.ToString("#######0.0", CultureInfo.CurrentCulture);
        }


        protected override void ResetMembers() {
            this.Value = 0;
            base.ResetMembers();
        }

    }
}
